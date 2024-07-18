namespace FirstApp.Services
{
    public class Functions : IFunctions
    {
        public string CambiarTexto(string text, int count) => $"{text} , {count}";
    }
}
