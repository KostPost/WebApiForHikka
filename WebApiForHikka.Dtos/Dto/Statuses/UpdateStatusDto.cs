﻿using WebApiForHikka.Dtos.Shared;

namespace WebApiForHikka.Dtos.Dto.Status;
public class UpdateStatusDto : UpdateDtoWithSeoAddition
{
    public required string Name { get; set; }
}