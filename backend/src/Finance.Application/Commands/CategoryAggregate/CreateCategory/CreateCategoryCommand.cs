﻿using Core.Messages;
using Finance.Domain.Aggregates;
using MediatR;

namespace Finance.Application.Commands.CategoryAggregate.CreateCategory;

public record CreateCategoryCommand(string Name, 
                                    string Color, 
                                    Guid? ParentId) : IRequest<Category>, IMessage;