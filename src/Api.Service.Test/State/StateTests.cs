using System;
using System.Collections.Generic;
using Api.Domain.Dtos.State;

namespace Api.Service.Test.Uf
{
    public class StateTests
    {
        public static string Name { get; set; }
        public static string Initials { get; set; }
        public static Guid StateId { get; set; }

        public List<StateDto> listaUfDto = new List<StateDto>();
        public StateDto stateDto;

        public StateTests()
        {
            StateId = Guid.NewGuid();
            Initials = "AS";
            Name = "Any_Name";

            for (int i = 0; i < 10; i++)
            {
                var dto = new StateDto()
                {
                    Id = Guid.NewGuid(),
                    Initials = Initials,
                    Name = Name
                };
                listaUfDto.Add(dto);
            };

            stateDto = new StateDto
            {
                Id = StateId,
                Initials = Initials,
                Name = Name
            };
        }

    }
}
