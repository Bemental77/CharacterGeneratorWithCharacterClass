
'Author: Casey Bement
'Purpose: Manage a character
'Date: 09/29/2021

Option Strict On
Option Explicit On


Public Class Character
    Private mstrName As String
    Private mstrRace As String
    Private mlstStats As List(Of Integer)

    Public Property Name As String
        Get
            Return mstrName
        End Get
        Set(value As String)
            mstrName = value
        End Set
    End Property

    Public Property Race As String
        Get
            Return mstrRace
        End Get
        Set(value As String)
            mstrRace = value
        End Set
    End Property

    Public Property Stats As List(Of Integer)
        Get
            Return mlstStats
        End Get
        Set(value As List(Of Integer))
            mlstStats = value
        End Set
    End Property

    Public Sub New()
        mstrName = String.Empty
        mstrRace = String.Empty
        mlstStats = New List(Of Integer)
        For intCount = 1 To 6
            mlstStats.Add(0)
        Next
    End Sub

    Public Function FullName() As String
        Return Name & " the " & Race
    End Function

End Class
