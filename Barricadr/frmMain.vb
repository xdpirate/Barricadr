Imports System.IO
Imports System.Security.Principal
Imports System.Text.RegularExpressions

Public Class frmMain
    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        If Directory.Exists(txtPath.Text) Then
            dirPicker.SelectedPath = txtPath.Text
        End If

        If dirPicker.ShowDialog = DialogResult.OK Then
            txtPath.Text = dirPicker.SelectedPath
        End If
    End Sub

    Private Sub ButtonHandler(sender As Object, e As EventArgs) Handles btnBlock.Click, btnAllow.Click, btnRestore.Click
        Dim action As String = sender.Tag

        If action = "restoreall" Then
            If MessageBox.Show("This will permanently delete all rules set by Barricadr. Continue?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                lblHeader.Text = "Cleaning..."
                'netsh advfirewall firewall show rule status=enabled name=all | FIND /I "Barricadr Block"
                Dim tempBatchFile As String = System.IO.Path.GetTempPath() & Guid.NewGuid().ToString() & ".bat"
                File.WriteAllText(tempBatchFile, $"@echo off{vbNewLine}netsh advfirewall firewall show rule status=enabled name=all | FIND /I ""Barricadr Block""")
                Dim batchy As Process = New System.Diagnostics.Process()

                With batchy.StartInfo
                    .FileName = tempBatchFile
                    .UseShellExecute = False
                    .RedirectStandardOutput = True
                    .CreateNoWindow = True
                    .WindowStyle = ProcessWindowStyle.Hidden
                End With

                batchy.Start()
                Dim batchyOutput As String = batchy.StandardOutput.ReadToEnd
                batchy.WaitForExit()

                File.Delete(tempBatchFile)

                Dim rules As String() = batchyOutput.Split(vbNewLine)

                For i As Integer = 0 To rules.Count - 1 Step 1
                    rules(i) = Regex.Replace(rules(i).Trim(), "^Rule Name:\s+", "")
                Next

                RemoveAllRules(rules)

                lblHeader.Text = "Barricadr"
                If MessageBox.Show("Finished! Open Windows Firewall to review changes?", Application.ProductName,
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    Process.Start("wf.msc")
                End If

                btnRestore.Tag = "restore"
                btnRestore.Text = "&Restore"
                btnRestore.BackColor = Color.LightSkyBlue
            End If
        Else
            Dim executables As List(Of String) = GetExecutables(txtPath.Text)

            If executables.Count > 0 Then
                Dim strList As String = ""
                For Each entry In executables
                    strList &= entry & vbNewLine
                Next

                Dim questionFragment As String = ""

                If action = "block" Then
                    questionFragment = "create firewall blocking rules"
                ElseIf action = "allow" Then
                    questionFragment = "create firewall allow rules"
                ElseIf action = "restore" Then
                    questionFragment = "remove all Barricadr-created firewall rules"
                End If


                Dim msg As String = $"Barricadr found {executables.Count} executable files in the chosen directory " &
                                    $"tree. Are you sure you want to {questionFragment} for all of these " &
                                    $"executables?{vbNewLine}{vbNewLine}Found executables:{vbNewLine}{strList}"

                If MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    lblHeader.Text = "Cleaning..."
                    RemoveRules(executables)

                    If Not action = "restore" Then
                        For Each entry In executables
                            If action = "block" Then
                                lblHeader.Text = "Barricading..."
                            Else
                                lblHeader.Text = "Opening floodgates..."
                            End If

                            CreateRules(entry, action)
                        Next
                    End If

                    lblHeader.Text = "Barricadr"
                    If MessageBox.Show("Finished! Open Windows Firewall to review changes?", Application.ProductName,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                        Process.Start("wf.msc")
                    End If
                End If
            Else
                MessageBox.Show("No executables found within the given path, or the path is invalid.",
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Function GetExecutables(dir) As List(Of String)
        Dim recursive As SearchOption = SearchOption.AllDirectories
        If chkRecursiveScan.Checked = False Then
            recursive = SearchOption.TopDirectoryOnly
        End If

        If Directory.Exists(dir) Then
            Return Directory.EnumerateFiles(dir, "*", recursive).Where(
                Function(file) _
                    file.ToLower().EndsWith(".exe") OrElse
                    file.ToLower().EndsWith(".msi") OrElse
                    file.ToLower().EndsWith(".msix") OrElse
                    file.ToLower().EndsWith(".appx") OrElse
                    file.ToLower().EndsWith(".appxbundle") OrElse
                    file.ToLower().EndsWith(".bat") OrElse
                    file.ToLower().EndsWith(".ps1") OrElse
                    file.ToLower().EndsWith(".vbs") OrElse
                    file.ToLower().EndsWith(".jar") OrElse
                    file.ToLower().EndsWith(".cmd")
            ).ToList()
        Else
            Return New List(Of String)
        End If
    End Function

    Private Sub CreateRules(ByVal exePath As String, ByVal action As String)
        Dim netshProcess As Process = New System.Diagnostics.Process()

        With netshProcess.StartInfo
            .FileName = "netsh"
            .UseShellExecute = False
            .RedirectStandardOutput = True
            .CreateNoWindow = True
            .WindowStyle = ProcessWindowStyle.Hidden
        End With

        netshProcess.StartInfo.Arguments = "advfirewall firewall add rule name=""Barricadr " & Char.ToUpper(action(0)) & action.Substring(1) & " Inbound: " & exePath & """ dir=in program=""" & exePath & """ action=" & action & " enable=yes"
        netshProcess.Start()
        netshProcess.WaitForExit()
        netshProcess.StartInfo.Arguments = "advfirewall firewall add rule name=""Barricadr " & Char.ToUpper(action(0)) & action.Substring(1) & " Outbound: " & exePath & """ dir=out program=""" & exePath & """ action=" & action & " enable=yes"
        netshProcess.Start()
        netshProcess.WaitForExit()
    End Sub

    Private Sub RemoveRules(ByVal executables As List(Of String))
        For Each entry In executables
            Dim netshProcess As Process = New System.Diagnostics.Process()

            With netshProcess.StartInfo
                .FileName = "netsh"
                .UseShellExecute = False
                .RedirectStandardOutput = True
                .CreateNoWindow = True
                .WindowStyle = ProcessWindowStyle.Hidden
            End With

            netshProcess.StartInfo.Arguments = "advfirewall firewall delete rule name=""Barricadr Block Inbound: " & entry & """"
            netshProcess.Start()
            netshProcess.WaitForExit()
            netshProcess.StartInfo.Arguments = "advfirewall firewall delete rule name=""Barricadr Allow Inbound: " & entry & """"
            netshProcess.Start()
            netshProcess.WaitForExit()
            netshProcess.StartInfo.Arguments = "advfirewall firewall delete rule name=""Barricadr Block Outbound: " & entry & """"
            netshProcess.Start()
            netshProcess.WaitForExit()
            netshProcess.StartInfo.Arguments = "advfirewall firewall delete rule name=""Barricadr Allow Outbound: " & entry & """"
            netshProcess.Start()
            netshProcess.WaitForExit()
        Next
    End Sub

    Private Sub RemoveAllRules(ByVal rules As String())
        For Each rule In rules
            Dim netshProcess As Process = New System.Diagnostics.Process()

            With netshProcess.StartInfo
                .FileName = "netsh"
                .UseShellExecute = False
                .RedirectStandardOutput = True
                .CreateNoWindow = True
                .WindowStyle = ProcessWindowStyle.Hidden
            End With

            netshProcess.StartInfo.Arguments = "advfirewall firewall delete rule name=""" & rule & """"
            netshProcess.Start()
            netshProcess.WaitForExit()
        Next
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        'Check if we started as admin - if not, relaunch and quit
        If Not WindowsIdentity.GetCurrent().Owner.IsWellKnown(WellKnownSidType.BuiltinAdministratorsSid) Then
            Dim p As Process = New System.Diagnostics.Process()

            With p.StartInfo
                .FileName = Application.ExecutablePath
                .Verb = "RunAs"
            End With

            Try
                p.Start()
            Catch ex As Exception
                MessageBox.Show("Barricadr requires administrator rights in order to function.", Application.ProductName,
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Application.Exit()
        End If
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.ShiftKey Then
            btnRestore.Tag = "restoreall"
            btnRestore.Text = "&Restore all"
            btnRestore.BackColor = Color.Orange
        End If
    End Sub

    Private Sub frmMain_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.ShiftKey Then
            btnRestore.Tag = "restore"
            btnRestore.Text = "&Restore"
            btnRestore.BackColor = Color.LightSkyBlue
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkGithub.LinkClicked
        System.Diagnostics.Process.Start("https://github.com/xdpirate/Barricadr")
    End Sub

    Private Sub DarkMode(ByVal enable As Boolean)
        If enable Then
            Me.ForeColor = Color.White
            Me.BackColor = Color.FromArgb(50, 50, 50)
            txtPath.ForeColor = Color.White
            txtPath.BackColor = Color.Black
            btnBrowse.ForeColor = Color.White
            btnBrowse.BackColor = Color.Black
            btnBlock.ForeColor = Color.Black
            btnAllow.ForeColor = Color.Black
            btnRestore.ForeColor = Color.Black
            lnkGithub.LinkColor = Color.White
            lnkGithub.VisitedLinkColor = Color.Gray
            lnkGithub.ActiveLinkColor = Color.DarkGray
            lblCaution.ForeColor = Color.Salmon
        Else
            Me.ForeColor = SystemColors.ControlText
            Me.BackColor = SystemColors.Control
            txtPath.ForeColor = SystemColors.ControlText
            txtPath.BackColor = SystemColors.Control
            btnBrowse.ForeColor = SystemColors.ControlText
            btnBrowse.BackColor = SystemColors.Control
            btnBlock.ForeColor = SystemColors.ControlText
            btnAllow.ForeColor = SystemColors.ControlText
            btnRestore.ForeColor = SystemColors.ControlText
            lnkGithub.LinkColor = Color.Blue
            lnkGithub.VisitedLinkColor = Color.Purple
            lnkGithub.ActiveLinkColor = Color.Red
            lblCaution.ForeColor = Color.Red
        End If
    End Sub

    Private Sub chkDarkMode_CheckedChanged(sender As Object, e As EventArgs) Handles chkDarkMode.CheckedChanged
        DarkMode(chkDarkMode.Checked)
    End Sub
End Class
