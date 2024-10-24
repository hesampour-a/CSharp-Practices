﻿using Library.Entities.Lends;
using Library.Services.Lends.Contracts;
using Library.Services.Lends.Contracts.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Ef.Lends;

public class EfLendQuery(EfDataContext dbContext) : LendQuery
{
    public async Task<Lend> GetById(int id)
    {
        return await dbContext.Lends.FirstOrDefaultAsync(_ => _.Id == id);
    }

    public async Task<IEnumerable<ShowLendDto>> GetAll(int? bookId,
        int? userId)
    {
        var baseQuery = dbContext.Lends.AsQueryable();

        if (bookId != null)
            baseQuery = baseQuery.Where(_ => _.BookId == bookId);
        if (userId != null)
            baseQuery = baseQuery.Where(_ => _.UserId == userId);

        return await baseQuery.Select(_ => new ShowLendDto
        {
            BookId = _.BookId,
            Id = _.Id,
            UserId = _.UserId,
            LendDate = _.LendDate,
            ReturnDate = _.ReturnDate,
            IsReturned = _.IsReturned
        }).ToListAsync();
    }

    public async Task<IEnumerable<ShowActiveLendDto>> GetAllActives(
        int? bookId, int? userId)
    {
        var baseQuery = dbContext.Lends.AsQueryable();

        if (bookId != null)
            baseQuery = baseQuery.Where(_ => _.BookId == bookId);
        if (userId != null)
            baseQuery = baseQuery.Where(_ => _.UserId == userId);

        return await baseQuery.Where(_ => _.IsReturned == false)
            .Include(_ => _.User).Include(_ => _.Book).Select(_ =>
                new ShowActiveLendDto
                {
                    BookName = _.Book.Title,
                    Id = _.Id,
                    UserName = _.User.Name,
                    LendDate = _.LendDate,
                    ReturnDate = _.ReturnDate
                }).ToListAsync();
    }
}