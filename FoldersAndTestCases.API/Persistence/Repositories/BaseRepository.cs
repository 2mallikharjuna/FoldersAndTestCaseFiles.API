﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoldersAndTestCases.API.Persistence.Contexts;

namespace FoldersAndTestCases.API.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
