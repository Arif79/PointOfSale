﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PointOfSaleProject.Models.Context;
using PointOfSaleProject.Models.EntityModels;
using PointOfSaleProject.Models.ViewModel;

namespace PointOfSaleProject.DAL
{
    public class OrganizationDAL
    {
        POSDbContext dbContext = new POSDbContext();
        public List<Organization> GetOrganizationList()
        {
            var list = dbContext.Organizations.ToList();
            return list;
        }
        public string GetOrganizationCode()
        {
            long code;

            if (dbContext.Organizations.ToList().Count > 0)
            {
                code = Convert.ToInt64(dbContext.Organizations.Select(x => x.Code).Max());
            }
            else
            {
                code = 0;
            }

            return string.Format("{0:000}", (code + 1));
        }
        public bool IsOrganizationSaved(OrganizationVM itemVm)
        {
            Organization item = new Organization()
            {
                Name = itemVm.Name,
                Code = itemVm.Code,
                Contact = itemVm.Contact,
                Address = itemVm.Address,
                Image = itemVm.Image,
                Date = itemVm.Date

            };

            dbContext.Organizations.Add(item);
            var isAdded = dbContext.SaveChanges();

            if (isAdded > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}