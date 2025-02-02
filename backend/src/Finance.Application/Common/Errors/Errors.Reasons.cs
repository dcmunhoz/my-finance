using Result;

namespace Finance.Application.Common.Errors;

public static partial class Errors
{
    public static class Reasons
    {
        public static ResultError DescriptionExistent => new ResultError(nameof(DescriptionExistent), "Descrição existente", "Já existe um motivo com a descrição informada.");
    }
}