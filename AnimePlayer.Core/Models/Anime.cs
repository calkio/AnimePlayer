﻿using CSharpFunctionalExtensions;

namespace AnimePlayer.Core.Models
{
    public class Anime
    {
        public const int MIN_YEAR_ANIME = 1950;
        public const int MAX_COUNT_SYMBOL_TITLE = 300;

        private Anime(Guid id, string title, string description, int yearIssue)
        {
            Id = id;
            Title = title;
            Description = description;
            YearIssue = yearIssue;
        }

        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public int YearIssue { get; }

        public static Result<Anime> Create(Guid id, string title, string description, int yearIssue)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > MAX_COUNT_SYMBOL_TITLE)
            {
                return Result.Failure<Anime>("Title");
            }
            if (yearIssue < MIN_YEAR_ANIME)
            {
                return Result.Failure<Anime>("YearIssue");
            }

            var anime = new Anime(id, title, description, yearIssue);

            return Result.Success<Anime>(anime);
        }
    }
}
