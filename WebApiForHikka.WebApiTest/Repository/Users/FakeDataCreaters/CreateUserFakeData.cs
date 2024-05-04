﻿
using WebApiForHikka.Dtos.Dto.Users;
using WebApiForHikka.EfPersistence.Data;

namespace WebApiForHikka.WebApiTest.Repository.Users.FakeDataCreaters;
public static class CreateUserFakeData
{
    public static async Task<List<Guid>> CreateUsersWithRoleAsync(HikkaDbContext databaseContext, string role, uint howManyCreate) 
    {
        List<Guid> ids = new List<Guid>();
        for (int i = 0;i<howManyCreate; ++i) 
        {
            ids.Add(Guid.NewGuid());
                databaseContext.Users.Add(
                    new Domain.Models.User(
                        )
                    {
                        Email = $"test{i+role}@gmail.com",
                        Id = ids[i],
                        Password = i.ToString(),
                        Role = role,
                    }
                    );
                await databaseContext.SaveChangesAsync();
        }

        return ids;
    }
}
