Imports System.Data.SqlClient

Public Class AdministracionPreguntas

    Dim DB As cLibSQL.cLibSQL

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Opciones.Show()
        Me.Close()
    End Sub

    Private Sub AdministracionPreguntas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        'ComboBox1.Items.Add("TODAS")
        'ComboBox1.Items.Add("ESPAÑOL")
        'ComboBox1.Items.Add("MATEMATICAS")
        'ComboBox1.Items.Add("CIENCIAS NATURALES")
        Dim dt As DataTable
        Dim i As Int16

        DB = New cLibSQL.cLibSQL("Data Source=LOCALHOST;Initial Catalog=DB_ROBOTS;Integrated Security=True")
        DB.NOMBRE_STORED_PROCEDURE = "MUESTRA_MATERIAS"

        dt = DB.REGRESA_DATATABLE

        'Me.ComboBox1.DataSource = DB.REGRESA_DATATABLE
        Me.ComboBox1.Items.Add("TODAS")

        For i = 0 To dt.Rows.Count - 1
            Me.ComboBox1.Items.Add(dt.Rows(i).Item("MATERIA").ToString)
        Next

        'Me.ComboBox1.DisplayMember = "MATERIA"
        'Me.ComboBox1.ValueMember = "MATERIA"
        'Me.ComboBox1.Refresh()


        'DB.LIBERA_RECURSOS()
        DB = Nothing
        
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        DataGridView1.DataSource = Nothing
        DB = New cLibSQL.cLibSQL("Data Source=LOCALHOST;Initial Catalog=DB_ROBOTS;Integrated Security=True")
        DB.NOMBRE_STORED_PROCEDURE = "VIS_C_EXAMEN_PREG_RESP"
        DB.AGREGA_PARAMETROS("SELECCION", ComboBox1.Text, SqlDbType.VarChar, ParameterDirection.Input, 20)
        DataGridView1.DataSource = DB.REGRESA_DATATABLE
        DB.LIBERA_RECURSOS()
        DB = Nothing

    End Sub

    Private Sub Insertar(sender As Object, e As EventArgs) Handles Button2.Click
        DB = New cLibSQL.cLibSQL("Data Source=LOCALHOST;Initial Catalog=DB_ROBOTS;Integrated Security=True")

        Dim materia As String = TextBox10.Text
        Dim idMateria As Integer
        If materia.Equals("Matematicas") Or materia.Equals("MATEMATICAS") Then
            idMateria = 2

        ElseIf materia.Equals("Español") Or materia.Equals("ESPAÑOL") Then
            idMateria = 1

        ElseIf materia.Equals("Ciencias Naturales") Or materia.Equals("CIENCIAS NATURALES") Then
            idMateria = 3
        End If
        DB.NOMBRE_STORED_PROCEDURE = "AGREGAR_C_EXAMEN_PREG_RESP"
        DB.AGREGA_PARAMETROS("ID_EXAMEN", VBMath.Rnd, SqlDbType.Int, ParameterDirection.Input)
        DB.AGREGA_PARAMETROS("ID_MATERIA", idMateria, SqlDbType.Int, ParameterDirection.Input)
        DB.AGREGA_PARAMETROS("NUM_PREGUNTA", TextBox1.Text, SqlDbType.Int, ParameterDirection.Input)
        DB.AGREGA_PARAMETROS("NOMBRE_EXAMEN", TextBox2.Text, SqlDbType.VarChar, ParameterDirection.Input, 60)
        DB.AGREGA_PARAMETROS("DESCRIPCION_EXAMEN", TextBox3.Text, SqlDbType.VarChar, ParameterDirection.Input, 300)
        DB.AGREGA_PARAMETROS("PREGUNTA", TextBox4.Text, SqlDbType.VarChar, ParameterDirection.Input, 80)
        DB.AGREGA_PARAMETROS("RESPUESTA_OPC1", TextBox5.Text, SqlDbType.VarChar, ParameterDirection.Input, 40)
        DB.AGREGA_PARAMETROS("RESPUESTA_OPC2", TextBox6.Text, SqlDbType.VarChar, ParameterDirection.Input, 40)
        DB.AGREGA_PARAMETROS("RESPUESTA_OPC3", TextBox7.Text, SqlDbType.VarChar, ParameterDirection.Input, 40)
        DB.AGREGA_PARAMETROS("RESPUESTA_CORRECTA", TextBox8.Text, SqlDbType.VarChar, ParameterDirection.Input, 20)
        DB.AGREGA_PARAMETROS("AVANZAR_JUGADOR", TextBox9.Text, SqlDbType.VarChar, ParameterDirection.Input, 1)
        DB.EJECUTA_NONQUERY()

        DB.LIBERA_RECURSOS()
        DB = Nothing

        DB = New cLibSQL.cLibSQL("Data Source=LOCALHOST;Initial Catalog=DB_ROBOTS;Integrated Security=True")
        DB.NOMBRE_STORED_PROCEDURE = "VIS_C_EXAMEN_PREG_RESP"
        DB.AGREGA_PARAMETROS("SELECCION", TextBox4.Text, SqlDbType.VarChar, ParameterDirection.Input, 20)
        DataGridView1.DataSource = DB.REGRESA_DATATABLE
        DB.LIBERA_RECURSOS()
        DB = Nothing
    End Sub

    Private Sub Borrar(sender As Object, e As EventArgs) Handles Button3.Click
        DB = New cLibSQL.cLibSQL("Data Source=LOCALHOST;Initial Catalog=DB_ROBOTS;Integrated Security=True")
        DB.NOMBRE_STORED_PROCEDURE = "ELIMINAR_C_EXAMEN_PREG_RESP"
        DB.AGREGA_PARAMETROS("PREGUNTA", TextBox4.Text, SqlDbType.VarChar, ParameterDirection.Input, 80)
        DB.EJECUTA_NONQUERY()


        DataGridView1.DataSource = Nothing
        DB = New cLibSQL.cLibSQL("Data Source=LOCALHOST;Initial Catalog=DB_ROBOTS;Integrated Security=True")
        DB.NOMBRE_STORED_PROCEDURE = "VIS_C_EXAMEN_PREG_RESP"
        DB.AGREGA_PARAMETROS("SELECCION", TextBox4.Text, SqlDbType.VarChar, ParameterDirection.Input, 20)
        DataGridView1.DataSource = DB.REGRESA_DATATABLE
        DB.LIBERA_RECURSOS()
        DB = Nothing

    End Sub

    Private Sub Buscar(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dt As DataTable

        DB = New cLibSQL.cLibSQL("Data Source=LOCALHOST;Initial Catalog=DB_ROBOTS;Integrated Security=True")
        DB.NOMBRE_STORED_PROCEDURE = "buscar"
        DB.AGREGA_PARAMETROS("pregunta", TextBox4.Text, SqlDbType.VarChar, ParameterDirection.Input, 80)
        dt = DB.REGRESA_DATATABLE

        TextBox1.Text = dt.Rows(0).Item("NUM_PREGUNTA").ToString
        TextBox2.Text = dt.Rows(0).Item("NOMBRE_EXAMEN").ToString
        TextBox3.Text = dt.Rows(0).Item("DESCRIPCION_EXAMEN").ToString
        TextBox10.Text = dt.Rows(0).Item("MATERIA").ToString
        TextBox5.Text = dt.Rows(0).Item("RESPUESTA_OPC1").ToString
        TextBox6.Text = dt.Rows(0).Item("RESPUESTA_OPC2").ToString
        TextBox7.Text = dt.Rows(0).Item("RESPUESTA_OPC3").ToString
        TextBox8.Text = dt.Rows(0).Item("RESPUESTA_CORRECTA").ToString
        TextBox9.Text = dt.Rows(0).Item("AVANZAR_JUGADOR").ToString

        'DataGridView1.DataSource = dt

        ComboBox1.SelectedItem = dt.Rows(0).Item("MATERIA").ToString

        'DB.LIBERA_RECURSOS()

    End Sub

    Private Sub Actualizar(sender As Object, e As EventArgs) Handles Button4.Click
        DB = New cLibSQL.cLibSQL("Data Source=LOCALHOST;Initial Catalog=DB_ROBOTS;Integrated Security=True")
        DB.NOMBRE_STORED_PROCEDURE = "ACT_C_EXAMEN_PREG_RESP"

        DB.AGREGA_PARAMETROS("PREGUNTA", TextBox4.Text, SqlDbType.VarChar, ParameterDirection.Input, 80)
        DB.AGREGA_PARAMETROS("RESPUESTA_OPC1", TextBox5.Text, SqlDbType.VarChar, ParameterDirection.Input, 40)
        DB.AGREGA_PARAMETROS("RESPUESTA_OPC2", TextBox6.Text, SqlDbType.VarChar, ParameterDirection.Input, 40)
        DB.AGREGA_PARAMETROS("RESPUESTA_OPC3", TextBox7.Text, SqlDbType.VarChar, ParameterDirection.Input, 40)
        DB.AGREGA_PARAMETROS("RESPUESTA_CORRECTA", TextBox8.Text, SqlDbType.VarChar, ParameterDirection.Input, 20)
        DB.EJECUTA_NONQUERY()

        DB.LIBERA_RECURSOS()
        DB = Nothing
    End Sub
End Class