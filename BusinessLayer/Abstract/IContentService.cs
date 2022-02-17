﻿using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList(string p);
        List<Content> GetListByWriter(int id);

        List<Content> GetListByHeadingID(int id);
        void CategoryAdd(Content content);
        Content GetByID(int id);
        void contentDelete(Content content);
        void ContentUpdate(Content content);
        void ContentAdd(Content content);

    }
}
