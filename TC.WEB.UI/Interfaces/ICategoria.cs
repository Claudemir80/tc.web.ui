using TC.WEB.UI.Models;

namespace TC.WEB.UI.Interfaces
{
    public interface ICategoria
    {
        List<Categoria> Get();

        Categoria Create(Categoria categoria);

        Categoria Update(Categoria categoria);

        Categoria GetOne(int id);

        Categoria Delete(int id);
    }
}
