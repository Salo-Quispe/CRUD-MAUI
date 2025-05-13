using squispe5A.Model;

namespace squispe5A.Views;

public partial class vHome : ContentPage
{
	public vHome()
	{
		InitializeComponent();
	}

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = " ";
        App.personRepo.AddNewPerson(txtNombre.Text, txtApellido.Text);
        statusMessage.Text = App.personRepo.statusMessage;
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        List<Persona> lista = App.personRepo.GetAllPerson();
        listarPersona.ItemsSource = lista;
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        if (int.TryParse(txtId.Text, out int id))
        {
            App.personRepo.UpdatePerson(id, txtNombre.Text, txtApellido.Text);
            statusMessage.Text = App.personRepo.statusMessage;
        }
        else
        {
            statusMessage.Text = "Selecciona un elemento para actualizar.";
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        if (int.TryParse(txtId.Text, out int id))
        {
            App.personRepo.DeletePerson(id);
            statusMessage.Text = App.personRepo.statusMessage;
        }
        else
        {
            statusMessage.Text = "Selecciona un elemento para eliminar.";
        }
    }
    private void listarPersona_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selected = e.CurrentSelection.FirstOrDefault() as Persona;
        if (selected != null)
        {
            txtId.Text = selected.Id.ToString();
            txtNombre.Text = selected.Name;
            txtApellido.Text = selected.LastName;
        }
    }

    private void btnEliminarTodo_Clicked_1(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        App.personRepo.ResetPersonTable();
        statusMessage.Text = App.personRepo.statusMessage;
        listarPersona.ItemsSource = App.personRepo.GetAllPerson();
    }
}