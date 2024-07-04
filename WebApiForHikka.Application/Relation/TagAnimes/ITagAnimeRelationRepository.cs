﻿using WebApiForHikka.Application.Shared.Relation;
using WebApiForHikka.Domain.Models;
using WebApiForHikka.Domain.Models.ManyToMany;
using WebApiForHikka.Domain.Models.WithSeoAddition;

namespace WebApiForHikka.Application.Relation.TagAnimes;
public interface ITagAnimeRelationRepository : IRelationCrudRepository<TagAnime, Tag, Anime>;