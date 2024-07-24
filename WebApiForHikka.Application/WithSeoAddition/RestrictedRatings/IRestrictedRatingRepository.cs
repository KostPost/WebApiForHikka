﻿using WebApiForHikka.Application.Shared;
using WebApiForHikka.Domain.Models.WithSeoAddition;

namespace WebApiForHikka.Application.WithSeoAddition.RestrictedRatings;

public interface IRestrictedRatingRepository : ICrudRepository<RestrictedRating>;