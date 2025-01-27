using Result;

namespace Finance.Application.Common.Errors;

public static partial class Error
{
    public static class Category
    {
        public static ResultError CategoryInexistent => new("Categoria inexistente", "Categoria informada não existe");
        public static ResultError ParentInexistent => new("Categoria inexistente", "Categoria pai informada não existe");
        public static ResultError CategoryWithSameDescription => new("Categoria já exsite","Já existe uma categoria com a descrição informada");
    }
}