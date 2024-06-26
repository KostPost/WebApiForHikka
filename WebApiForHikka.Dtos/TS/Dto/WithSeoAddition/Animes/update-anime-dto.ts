/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { UpdateDtoWithSeoAddition } from "../../../Shared/update-dto-with-seo-addition";

export interface UpdateAnimeDto extends UpdateDtoWithSeoAddition {
    kindId: string;
    statusId: string;
    periodId: string;
    restrictedRatingId: string;
    sourceId: string;
    name: string;
    imageName: string;
    romajiName: string;
    nativeName: string;
    posterPath: string;
    posterColors: number[];
    avgDuration: number;
    howManyEpisodes: number;
    firstAirDate: Date;
    lastAirDate: Date;
    tmdbId: number;
    shikimoriId: number;
    shikimoriScore: number;
    tmdbScore: number;
    imdbScore: number;
    isPublished: boolean;
    publishedAt: Date;
    updatedAt: Date;
    createdAt: Date;
}
