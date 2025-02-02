using Common.Domain;
using Common.Infra.Database.Interfaces;
using Finance.Domain.Aggregates.Reasons;

namespace Finance.Application.Common.Interface.Repository;

public interface IReasonRepository : IRepository<Reason>
{
    
}