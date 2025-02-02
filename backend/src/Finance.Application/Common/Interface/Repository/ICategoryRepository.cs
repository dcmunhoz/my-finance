using System.Linq.Expressions;
using Common.Domain;
using Common.Infra.Database.Interfaces;
using Finance.Domain.Aggregates.Categories;

namespace Finance.Application.Common.Interface.Repository;

public interface ICategoryRepository : IRepository<Category>;