using Result;

namespace Finance.Application.Common.Errors;

public static partial class Errors
{
    public static class Categories
    {
        public static ResultError CategoryNonExistent => new(nameof(CategoryNonExistent), "Categoria inexistente", "Categoria informada não existe");
        public static ResultError ParentNonExistent => new(nameof(ParentNonExistent), "Categoria inexistente", "Categoria pai informada não existe");
        public static ResultError CategoryWithSameDescription => new(nameof(CategoryWithSameDescription), "Categoria já exsite","Já existe uma categoria com a descrição informada");
    }
}