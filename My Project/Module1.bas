Module Module2
    Sub ����������_���������(���������� As String)

        Dim MSWord
        Dim DOK
        Dim ������, Tabl, ���������
        Dim ����������� As String, ����������� As String, ����������� As String, �������������� As String, ���������� As String
        Dim ����������� As Integer, ������� As Integer, ���������������2 As Integer, ��������������� As Integer, ���������������� As Integer
        Dim ���� As String, ������������� As String, ��������� As String, ��_���������� As String

        MSWord = CreateObject("Word.Application")

        ���� = �������������������.�����������.Value.ToShortDateString
        MSWord.DisplayAlerts = False
        DOK = MSWord.Documents.Add
        'MSWord.Visible = True

        ������������� = "SELECT ������, ������, ���������, ������, �������������� FROM ������ WHERE �����= " & Chr(39) & �������������������.�����������.Text & Chr(39)
        ������ = ���������������.���������������(�������������)


        ����������� = �������������(MSWord, DOK, ����, 1)
        If ����������� = 0 Then Exit Sub



        ����������� = "� ������� ���������� "
        ����������� = "� �������� ����������"
        ����������� = "� ������������ � ���������� �  ��������� ������������ ������������ � ����������� � ���������������� ������������ ���� ��� ����� ��������� ������, ����������� 21.06.2019"
        �������������� = "1. ��������� � �������� ���������� ��������� ���������� ������ � �" & �������������������.�����������.Text & "�, ������������� �� ���� ������� � ������� ��������� ���������������� ��������, ��������� ����������� ������� ����:"
        ���������� = "0"


        ����������� = �����������(DOK, �����������, ����������, �����������, �����������, �����������, ��������������, ����������)

        ��������� = �������.����������������(�������������������.�����������.Text)


        Tabl = DOK.Tables.Add(DOK.Range(0, 0), (UBound(���������, 2) + 1), 2)

        Call �������������������(MSWord, DOK, Tabl, ���������)

        Tabl.Range.Select
        MSWord.Selection.Cut
        ����������� = DOK.Paragraphs.Count

        Call ����������������(DOK, DOK.Paragraphs.Count, "", "Times New Roman", 14, 3, 0, 1, 0, False)
        ����������� = DOK.Paragraphs.Count
        DOK.Paragraphs(�����������).Range.Select
        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.PasteAndFormat(0)

        ����������� = DOK.Paragraphs.Count
        Call ����������������(DOK, �����������, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        ����������� = 1 + �����������
        Call ����������������(DOK, �����������, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        Call ����������������(DOK, �����������, "2. ��������� �������������� �������� �� �������������� ���������������� ��������� ��������� ������������ �" & ������(2, 0) & "� � �������:", "Times New Roman", 14, 3, 0, 1, 0, False)

        ����������� = 1 + �����������
        Call ����������������(DOK, �����������, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        ����������� = ����������������������(MSWord, DOK, ����, �����������)


        ��������������� = DOK.Range.Information(3)

        ����������� = DOK.Paragraphs.Count
        DOK.Paragraphs(�����������).Range.Delete
        ����������� = ����������� - 1
        ����������� = �������������������������(MSWord, DOK, ����, �����������)

        ���������������� = DOK.Range.Information(3)

        If ��������������� = ���������������� Then


            ���������������2 = ������.������������������������(DOK, �����������, ���������������)
            ����������� = DOK.Paragraphs.Count

            If ���������������2 <= 3 And ���������������2 >= 0 Then

                DOK.Tables(4).Range.Select

                MSWord.Selection.Cut

                ����������� = DOK.Paragraphs.Count

                ���������������2 = ������.������������������������(DOK, �����������, ���������������)

                While ���������������2 + 1 > 0

                    ����������� = 1 + �����������
                    Call ����������������(DOK, �����������, "", "Times New Roman", 14, 3, 0, 1, 0, False)
                    ���������������2 = ���������������2 - 1
                End While

                DOK.Paragraphs(�����������).Range.Select
                MSWord.Selection.PasteAndFormat(0)
                ����������� = DOK.Paragraphs.Count
            End If

            Call ����������������(DOK, �����������, "", "Times New Roman", 14, 3, 0, 1, 0, False)
            ����������� = 1 + �����������

            Call ����������������(DOK, �����������, "", "Times New Roman", 14, 3, 0, 1, 0, False)
            ����������� = 1 + �����������

            Call ����������������(DOK, �����������, "", "Times New Roman", 14, 3, 0, 1, 0, False)
            ����������� = DOK.Paragraphs.Count

        Else


            DOK.Tables(4).Range.Select

            MSWord.Selection.Cut

            ����������� = DOK.Paragraphs.Count
            ���������������2 = ������.������������������������(DOK, �����������, ���������������)


            While ���������������2 + 1 > 0

                ����������� = 1 + �����������
                Call ����������������(DOK, �����������, "", "Times New Roman", 14, 3, 0, 1, 0, False)
                ���������������2 = ���������������2 - 1
            End While
            DOK.Paragraphs(�����������).Range.Select

            MSWord.Selection.PasteAndFormat(0)

            DOK.Bookmarks("\EndOfDoc").Select

            ����������� = DOK.Paragraphs.Count
            Call ����������������(DOK, �����������, "", "Times New Roman", 14, 3, 0, 1, 0, False)

            ����������� = 1 + �����������
            Call ����������������(DOK, �����������, "", "Times New Roman", 14, 3, 0, 1, 0, False)

            ����������� = 1 + �����������
            Call ����������������(DOK, �����������, "", "Times New Roman", 14, 3, 0, 1, 0, False)


        End If

        ����������� = ���������������������(MSWord, DOK, �����������, ����������)

        ����������� = DOK.Paragraphs.Count
        DOK.Bookmarks("\EndOfDoc").Select

        ����������� = DOK.Paragraphs.Count
        Call ����������������(DOK, �����������, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Bookmarks("\EndOfDoc").Select

        ����������� = ������������������������(MSWord, DOK, ����, �����������, ����������)

        DOK.Bookmarks("\EndOfDoc").Select


        DOK.Bookmarks("\EndOfDoc").Select

        ����������� = DOK.Paragraphs.Count


        Call ���������������������(MSWord, DOK, �����������)

        ����������� = DOK.Paragraphs.Count


        ����������� = DOK.Paragraphs.Count

        Call ����������������(DOK, �����������, "", "Times New Roman", 14, 2, 0, 1, 0, False)


        Call ��������������������(MSWord, DOK, ������(2, 0).ToString, ������)


        MSWord.Visible = True

        Call ���������(DOK, ����������)

    End Sub


    Sub ��������������������(MSWord As Object, DOK As Object, ��������� As String, ������ As Object)

        Dim ����������� As Integer, �������������� As Integer
        Dim ���������
        Dim Tabl
        Dim ����������������������
        Dim ���� As String

        ���� = �������������������.�����������.Value.ToShortDateString

        DOK.Bookmarks("\EndOfDoc").Select

        ����������� = DOK.Paragraphs.Count

        Call ����������������(DOK, �����������, "�������� �" & ��������������, "Times New Roman", 14, 1, 0, 1, 0, False)

        ����������� = 1 + �����������
        Call ����������������(DOK, �����������, "��������� �������������� �������� �� ������������ ����������� �������� ", "Times New Roman", 14, 1, 0, 1, 0, False)

        ����������� = 1 + �����������
        Call ����������������(DOK, �����������, "��������� ���������� ��������� ���������������� �������������� ", "Times New Roman", 14, 1, 0, 1, 0, False)

        ����������� = 1 + �����������
        Call ����������������(DOK, �����������, "�" & ��������� & " � ", "Times New Roman", 14, 1, 0, 1, 0, False)

        ����������� = 1 + �����������
        Call ����������������(DOK, �����������, "�" & Left(����, 2) & "� " & month(Right(Left(����, 5), 2)) & " " & Right(����, 4), "Times New Roman", 14, 1, 0, 1, 0, False)

        ����������� = DOK.Paragraphs.Count
        Call ����������������(DOK, �����������, "", "Times New Roman", 14, 1, 0, 1, 0, False)

        ����������� = DOK.Paragraphs.Count
        Call ����������������(DOK, �����������, "��������������:", "Times New Roman", 14, 0, 0, 1, 0, False)

        ����������� = 1 + �����������
        Call ����������������(DOK, �����������, "������������ ��������: " & �����������(�������������������.�������������.Text), "Times New Roman", 14, 0, 0, 1, 0, False)

        ����������� = 1 + �����������
        Call ����������������(DOK, �����������, "����� ��������: " & �����������(�������������������.����������������������.Text) & ", " & �����������(�������������������.��������2.Text) & ", " & �����������(�������������������.��������3.Text), "Times New Roman", 14, 0, 0, 1, 0, False)

        ����������� = 1 + �����������
        Call ����������������(DOK, �����������, "��������� �������� � " & �����������(�������������������.�����������������.Text), "Times New Roman", 14, 0, 0, 1, 0, False)

        ����������� = DOK.Paragraphs.Count
        Call ����������������(DOK, �����������, "�������:", "Times New Roman", 14, 0, 0, 1, 0, False)

        Call ����������������(DOK, DOK.Paragraphs.Count, "� ����������� ����������� �������� ���������� ����������, ����������� � ���� ��� ����� ��������� ������ �� �������������� ���������������� ��������� ���������������� �������������� �" & ��������� & " � � ������ " & ������(3, 0) & " ���. � ������ � " & ������(0, 0) & " �� " & ������(1, 0), "Times New Roman", 14, 3, 0, 1, 0, False)

        Call ����������������(DOK, DOK.Paragraphs.Count, "", "Times New Roman", 14, 1, 0, 1, 0, False)

        Call ����������������(DOK, DOK.Paragraphs.Count, "�����������:", "Times New Roman", 14, 0, 0, 1, 0, False)

        Call ����������������(DOK, DOK.Paragraphs.Count, "� ����������� ����������� �������� ���������� ����������, ����������� � ���� ��� ����� ��������� ������ �� �������������� ���������������� ��������� ��������� ������������ �" & ��������� & " � � ������ " & ������(3, 0) & " ������� ���. � " & ������(0, 0) & " �� " & ������(1, 0), "Times New Roman", 14, 3, 0, 1, 0, False)

        ����������� = 1 + �����������

        ��������� = ����������������(�������������������.�����������.Text)

        Tabl = DOK.Tables.Add(DOK.Range(0, 0), UBound(���������, 2) + 3, 5)

        Call ������������������(MSWord, DOK, Tabl, ���������)

        Tabl.Range.Select
        MSWord.Selection.Cut
        ����������� = ����������� + 1

        Call ����������������(DOK, DOK.Paragraphs.Count, "", "Times New Roman", 14, 3, 0, 1, 0, False)
        ����������� = DOK.Paragraphs.Count
        DOK.Paragraphs(�����������).Range.Select
        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.PasteAndFormat(0)

        Call ����������������(DOK, DOK.Paragraphs.Count, "2. ����������, ��� � ���������� �������� ����������� ���������� ��������������� �������������� ���������������� ���������� ����.", "Times New Roman", 14, 3, 0, 1, 0, False)

        ���������������������� = DOK.Tables.Add(DOK.Range(0, 0), 5, 2)

        Call �������������������������������(DOK, ����������������������)

        ����������������������.Range.Select

        MSWord.Selection.Cut

        ����������� = DOK.Paragraphs.Count

        DOK.Paragraphs(�����������).Range.Select
        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.PasteAndFormat(0)


    End Sub

End Module


