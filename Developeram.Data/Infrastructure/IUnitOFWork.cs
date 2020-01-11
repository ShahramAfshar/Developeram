﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Developeram.Data.Repositories;


namespace ECommerce.Data
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        //1-Begin TransAction  2-Commit(SaveChange) 3-RollBack
         GroupRepository GroupRepository { get; }
         ArticleRepository ArticleRepository { get; }


        void Commit();
        Task<int> CommitAsync();


    }
}
