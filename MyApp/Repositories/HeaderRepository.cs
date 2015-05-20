﻿using MyApp.Models;
using MyApp.Models.Entity;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.Repositories
{
    public class HeaderRepository : IHeaderRepository
    {
        private readonly MyContext _context = new MyContext();

	    public HeaderRepository()
	    {

	    }

        // 検索
        public ICollection<Header> Search(Header condition)
        {
            var query = from h in _context.Headers 
                        select h;

            if (condition.Id != 0)
            {
                query = query.Where(h => h.Id == condition.Id);
            }

            if (!string.IsNullOrEmpty(condition.Title))
            {
                query = query.Where(h => h.Title.Contains(condition.Title));
            }

            return query.OrderBy(h => h.Id).ToList();
        }

        // IDと一致するレコードを取得
        public Header Find(int id)
        {
            return _context.Headers.Find(id);
        }

        // データ追加
        public void Add(Header Header)
        {
        }

        // データ削除
        public void Delete(Header Header)
        { 
        }

        // データ保存
        public void SaveChanges()
        {
        }

    }
}