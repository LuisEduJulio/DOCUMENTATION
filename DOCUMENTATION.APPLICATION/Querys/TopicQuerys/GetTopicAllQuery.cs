using DOCUMENTATION.CORE.Entities;
using MediatR;
using System.Collections.Generic;

namespace DOCUMENTATION.APPLICATION.Querys
{
    public class GetTopicAllQuery : IRequest<List<Topic>>
    {
    }
}