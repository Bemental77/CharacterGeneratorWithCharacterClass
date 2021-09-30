'Author: Kyle Loewenhagen
'Date: ##/##/####
'Purpose: Create a basic random character generator for a typical role-playing game.

Option Strict On
Option Explicit On

Imports System.ComponentModel
Public Class frmCharacter


    Dim rndNumberGen As New Random()
    Dim lstCharacters As New BindingList(Of Character)
    Dim objSelectedCharacter As Character

    Private Sub BtnRandonName_Click(sender As Object, e As EventArgs) Handles btnRandonName.Click
        'Create two Lists
        Dim lstNamePrefix As New List(Of String)
        Dim lstNameSuffix As New List(Of String)

        'Create Variables
        Dim strName As String

        'Create a Random Numbers
        Dim rndNumberPrefix As New Random()
        Dim rndNumberSuffix As New Random()

        'Populate Name Prefix List.
        lstNamePrefix.Add("Ru")
        lstNamePrefix.Add("Al")
        lstNamePrefix.Add("Cu")
        lstNamePrefix.Add("Gar")
        lstNamePrefix.Add("Arun")
        lstNamePrefix.Add("Mal")
        lstNamePrefix.Add("Val")
        lstNamePrefix.Add("Yir")
        lstNamePrefix.Add("Dru")
        lstNamePrefix.Add("Bar")
        lstNamePrefix.Add("Rin")
        lstNamePrefix.Add("Mir")
        lstNamePrefix.Add("Rel")
        lstNamePrefix.Add("Rul")
        lstNamePrefix.Add("Ril")
        lstNamePrefix.Add("Nir")
        lstNamePrefix.Add("Grel")
        lstNamePrefix.Add("Ind")

        'Populate Name Suffix List.
        lstNameSuffix.Add("del")
        lstNameSuffix.Add("dor")
        lstNameSuffix.Add("din")
        lstNameSuffix.Add("arn")
        lstNameSuffix.Add("fir")
        lstNameSuffix.Add("vir")
        lstNameSuffix.Add("vir")
        lstNameSuffix.Add("el")
        lstNameSuffix.Add("tir")
        lstNameSuffix.Add("los")
        lstNameSuffix.Add("os")
        lstNameSuffix.Add("on")
        lstNameSuffix.Add("lon")
        lstNameSuffix.Add("den")
        lstNameSuffix.Add("ven")
        lstNameSuffix.Add("vol")
        lstNameSuffix.Add("or")
        lstNameSuffix.Add("grim")
        lstNameSuffix.Add("ul")
        lstNameSuffix.Add("uz")

        'Generate Name
        strName = lstNamePrefix.Item(rndNumberPrefix.Next(lstNamePrefix.Count - 1)).ToString _
            & lstNameSuffix.Item(rndNumberSuffix.Next(lstNameSuffix.Count)).ToString

        'Output Name
        txtName.Text = strName
    End Sub

    Private Sub frmCharacter_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Add Races to the Combobox on Load
        cboRace.Items.Add("Human")
        cboRace.Items.Add("Elf")
        cboRace.Items.Add("Drawf")
        cboRace.Items.Add("Gnome")
        'Selects the first Race
        cboRace.SelectedIndex = 0

        'Set Character Binding List to Listbox
        lbxCharacters.DataSource = lstCharacters
        lbxCharacters.DisplayMember = "Name"
    End Sub

    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        'Select Race
        objSelectedCharacter.Race = cboRace.SelectedItem.ToString

        'Clear strStats
        objSelectedCharacter.Stats.Clear()

        'lstStats.Add(RollDice(6, 4, True))
        'lstStats.Add(RollDice(6, 4, True))
        'lstStats.Add(RollDice(6, 4, True))
        'lstStats.Add(RollDice(6, 4, True))
        'lstStats.Add(RollDice(6, 4, True))
        'lstStats.Add(RollDice(6, 4, True))

        For intCount = 1 To 6
            objSelectedCharacter.Stats.Add(RollDice(6, 4, True))
        Next

        If objSelectedCharacter.Race = "Elf" Then
            'Elves get bonus INT and DEX
            objSelectedCharacter.Stats(1) = objSelectedCharacter.Stats(1) + 2
            objSelectedCharacter.Stats(3) = objSelectedCharacter.Stats(4) + 2
        ElseIf objSelectedCharacter.Race = "Drawf" Then
            'Drawfs get bonus STR, CON and CHA - 1
            objSelectedCharacter.Stats(0) = objSelectedCharacter.Stats(0) + 1
            objSelectedCharacter.Stats(4) = objSelectedCharacter.Stats(4) + 1
            objSelectedCharacter.Stats(5) = objSelectedCharacter.Stats(5) - 2
        ElseIf objSelectedCharacter.Race = "Gnome" Then
            'Gnomes get bonus INT, WIS, STR -2
            objSelectedCharacter.Stats(1) = objSelectedCharacter.Stats(1) + 1
            objSelectedCharacter.Stats(2) = objSelectedCharacter.Stats(2) + 2
            objSelectedCharacter.Stats(0) = objSelectedCharacter.Stats(0) - 2
        End If

        Call DisplayStats()
    End Sub

    Private Function RollDice(intSides As Integer, intNumber As Integer, blnDropLow As Boolean) As Integer
        Dim lstDieRolls As New List(Of Integer)

        For intCounter As Integer = 1 To intNumber
            lstDieRolls.Add(rndNumberGen.Next(1, intSides + 1))
        Next

        If blnDropLow Then
            'Test the die rolls
            'For Each intNum As Integer In lstDieRolls
            '    MessageBox.Show(intNum.ToString)
            'Next
            'MessageBox.Show("Lowest die roll is " & lstDieRolls.Min.ToString)

            'Add up all die rolls except the lowest
            Dim intMinValue As Integer = lstDieRolls.Min
            lstDieRolls.Remove(intMinValue)
            Return lstDieRolls.Sum
        Else
            'Add up all die rolls
            Return lstDieRolls.Sum
        End If

    End Function

    Private Sub DisplayStats()
        'Output Stat Results
        If Not objSelectedCharacter Is Nothing Then
            lblNameStats.Text = objSelectedCharacter.FullName
            lblSTR.Text = objSelectedCharacter.Stats(0).ToString
            lblINT.Text = objSelectedCharacter.Stats(1).ToString
            lblWIS.Text = objSelectedCharacter.Stats(2).ToString
            lblDEX.Text = objSelectedCharacter.Stats(3).ToString
            lblCON.Text = objSelectedCharacter.Stats(4).ToString
            lblCHA.Text = objSelectedCharacter.Stats(5).ToString
        Else
            lblNameStats.Text = "*"
            lblSTR.Text = "*"
            lblINT.Text = "*"
            lblWIS.Text = "*"
            lblDEX.Text = "*"
            lblCON.Text = "*"
            lblCHA.Text = "*"
        End If

    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        'Instantiate a new Character
        Dim objCharacter As New Character()
        'Populate new Character's Properties
        objCharacter.Name = txtName.Text
        objCharacter.Race = cboRace.SelectedItem.ToString
        'Add new Character to list of Characters
        lstCharacters.Add(objCharacter)
        'Make the new Character the selcted Character
        objSelectedCharacter = objCharacter

        'Select the current character in the listbox
        lbxCharacters.SelectedItem = objCharacter

    End Sub

    Private Sub lbxCharacters_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxCharacters.SelectedIndexChanged
        If Not lbxCharacters.SelectedItem Is Nothing Then
            objSelectedCharacter = CType(lbxCharacters.SelectedItem, Character)
            DisplayStats()
        Else
            objSelectedCharacter = Nothing
            DisplayStats()
        End If


    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'Remove the selected Character
        lstCharacters.Remove(objSelectedCharacter)
        objSelectedCharacter = CType(lbxCharacters.SelectedItem, Character)
        DisplayStats()

    End Sub
End Class
