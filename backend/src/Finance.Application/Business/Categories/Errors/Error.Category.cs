using Result;

namespace Finance.Application.Business.Categories.Errors;

public static partial class Error
{
    public static class Category
    {
        public static ResultError ParentInexistent() => new("Categoria inexistente", "Categoria pai informada não existe");
        public static ResultError CategoryWithSameDescription() => new("Categoria já exsite","Já existe uma categoria com a descrição informada");
    }
}