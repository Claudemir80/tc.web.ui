using TC.WEB.UI.Models;

namespace TC.WEB.UI.Interfaces
{
    public interface IProduto
    {
        List<Produto> Get();

        Produto Create(Produto produto);

        Produto Update(Produto produto);

        Produto GetOne(int id);

        Produto Delete(int id);
    }
}
