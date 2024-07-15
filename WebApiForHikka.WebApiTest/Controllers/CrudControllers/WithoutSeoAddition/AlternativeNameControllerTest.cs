using Microsoft.Extensions.DependencyInjection;
using WebApiForHikka.Application.WithoutSeoAddition.AlternativeNames;
using WebApiForHikka.Application.WithSeoAddition.Animes;
using WebApiForHikka.Domain.Models.WithoutSeoAddition;
using WebApiForHikka.Dtos.Dto.WithoutSeoAddition.AlternativeNames;
using WebApiForHikka.Dtos.Shared;
using WebApiForHikka.EfPersistence.Repositories.WithoutSeoAddition;
using WebApiForHikka.EfPersistence.Repositories.WithSeoAddition;
using WebApiForHikka.Test.Controller.Shared;
using WebApiForHikka.Test.Shared.Models.WithoutSeoAddition;
using WebApiForHikka.Test.Shared.Models.WithSeoAddtion;
using WebApiForHikka.WebApi.Controllers.ControllersWithoutSeoAddition;

namespace WebApiForHikka.Test.Controllers.CrudControllers.WithoutSeoAddition;

public class AlternativeNameControllerTest : CrudControllerBaseTest<
    AlternativeNameController,
    AlternativeNameService,
    AlternativeName,
    IAlternativeNameRepository,
    UpdateAlternativeNameDto,
    CreateAlternativeNameDto,
    GetAlternativeNameDto,
    ReturnPageDto<GetAlternativeNameDto>
>
{
    protected override AllServicesInController GetAllServices(IServiceCollection alternativeServices)
    {
        var dbContext = GetDatabaseContext();

        var repository = new AlternativeNameRepository(dbContext);
        var userManager = GetUserManager(dbContext);
        var roleManager = GetRoleManager(dbContext);

        alternativeServices.AddSingleton(dbContext);
        alternativeServices.AddSingleton<IAnimeRepository, AnimeRepository>();
        alternativeServices.AddSingleton<IAnimeService, AnimeService>();

        return new AllServicesInController(new AlternativeNameService(repository), userManager, roleManager);
    }

    protected override async Task<AlternativeNameController> GetController(
        AllServicesInController allServicesInController, IServiceProvider alternativeServices)
    {
        return new AlternativeNameController(
            allServicesInController.CrudService,
            _mapper,
            await GetHttpContextAccessForAdminUser(allServicesInController.UserManager,
                allServicesInController.RoleManager),
            alternativeServices.GetRequiredService<IAnimeService>()
        );
    }

    protected override void MutationBeforeDtoCreation(CreateAlternativeNameDto createDto,
        AllServicesInController allServicesInController, IServiceProvider alternativeServices)
    {
        var anime = GetAnimeModels.GetSample();

        var animeService = alternativeServices.GetRequiredService<IAnimeService>();

        animeService.CreateAsync(anime, CancellationToken).Wait();

        createDto.AnimeId = anime.Id;
    }

    protected override void MutationBeforeDtoUpdate(UpdateAlternativeNameDto updateDto,
        AllServicesInController allServicesInController, IServiceProvider alternativeServices)
    {
        var anime = GetAnimeModels.GetSample();

        var animeService = alternativeServices.GetRequiredService<IAnimeService>();

        animeService.CreateAsync(anime, CancellationToken).Wait();

        updateDto.AnimeId = anime.Id;
    }

    protected override CreateAlternativeNameDto GetCreateDtoSample()
    {
        return GetAlternativeNameModels.GetCreateDtoSample();
    }

    protected override GetAlternativeNameDto GetGetDtoSample()
    {
        return GetAlternativeNameModels.GetGetDtoSample();
    }

    protected override UpdateAlternativeNameDto GetUpdateDtoSample()
    {
        return GetAlternativeNameModels.GetUpdateDtoSample();
    }

    protected override AlternativeName GetModelSample()
    {
        return GetAlternativeNameModels.GetSample();
    }
}