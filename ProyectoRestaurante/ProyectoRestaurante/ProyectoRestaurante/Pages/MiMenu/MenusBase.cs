namespace ProyectoRestaurante.Pages.MisMenus
{
    public class MenusBase
    {

        protected override async Task OnInitializedAsync()
        {
            lista = await MenuServicio.GetLista();
        }
    }
}