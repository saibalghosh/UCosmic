﻿using System;

namespace UCosmic.Domain.People
{
    public class GetPersonByIdQuery : BaseEntityQuery<Person>, IDefineQuery<Person>
    {
        public int Id { get; set; }
    }

    public class GetPersonByIdHandler : IHandleQueries<GetPersonByIdQuery, Person>
    {
        private readonly IQueryEntities _entities;

        public GetPersonByIdHandler(IQueryEntities entities)
        {
            _entities = entities;
        }

        public Person Handle(GetPersonByIdQuery query)
        {
            if (query == null) throw new ArgumentNullException("query");

            return _entities.Get<Person>()
                .EagerLoad(query.EagerLoad, _entities)
                .ById(query.Id)
            ;
        }
    }
}