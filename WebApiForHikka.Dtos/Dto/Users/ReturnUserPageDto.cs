﻿using WebApiForHikka.Domain.Models;

namespace WebApiForHikka.Dtos.Dto.Users;
public class ReturnUserPageDto
{
    public required IReadOnlyCollection<GetUserDto> Users { get; set; }
    public required int HowManyPages { get; set; }
}
