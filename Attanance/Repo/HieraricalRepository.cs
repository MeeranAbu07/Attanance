using Attanance.IRepo;
using Attanance.Models;
using Attanance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.Repo
{
    public class HieraricalRepository : IHieraricalRepository
    {
        private readonly AppDbContext _db;

        public HieraricalRepository(AppDbContext dataContext)
        {
            _db = dataContext;
        }
        public async Task<string> CreateParent(HieraricalViewModel hieraricalmodel)
        {
            try
            {
                HieraricalOrder hierarical = new HieraricalOrder()
                {
                    ParentName = hieraricalmodel.ParentName,
                    ParentId = hieraricalmodel.ParentId,

                };
                _db.HieraricalOrder.Add(hierarical);
                _db.SaveChanges();
                
                return "Successfully created";
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<List<HieraricalViewModel>> GetHieraricalById(int id, bool isRecursive, bool isDownwardDirection)
        {
            try
            {
                List<HieraricalViewModel> hieraricalViewModels = (from hirari in _db.HieraricalOrder
                                                                     where hirari.Id !=null
                                                                  select new HieraricalViewModel
                                                                  {
                                                                      Id = hirari.Id,
                                                                      ParentName = hirari.ParentName,
                                                                      ParentId = hirari.ParentId
                                                                  }).OrderBy(x => x.ParentId).ToList();
                
                
                HieraricalViewModel originalheadid = hieraricalViewModels.Where(x => x.Id == id).First();

                List<HieraricalViewModel> userbasicresponce = new List<HieraricalViewModel>();

                BuildHirarycal(hieraricalViewModels, userbasicresponce, originalheadid, isRecursive, isDownwardDirection);
                List<int> userId = userbasicresponce.Select(x => x.Id).ToList();

                var usercount = _db.HieraricalOrder.Where(x => userId.Contains(x.Id)).ToList();

                var result = userbasicresponce.Count() < 0 ? (from user in userbasicresponce
                                                              select new HieraricalViewModel
                                                              {
                                                                  Id = user.Id,
                                                                  ParentId = user.ParentId,
                                                                  ParentName = user.ParentName
                                                              }).OrderBy(x => x.ParentId).ToList() : userbasicresponce;

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public void BuildHirarycal(List<HieraricalViewModel> sourceData, List<HieraricalViewModel> response,
            HieraricalViewModel current, bool isRecursive, bool isDirectionDownwards)
        {
            response.Add(current);
            List<HieraricalViewModel> collection = new List<HieraricalViewModel>();
            if (isDirectionDownwards)
            {
                collection = sourceData.Where(x => x.ParentId == current.Id && x.Id != current.Id).ToList();
            }
            else
            {
                collection = sourceData.Where(x => x.Id == current.ParentId && x.ParentId != current.ParentId).ToList();
            }

            if (!isRecursive)
            {
                response.AddRange(collection);
                return;
            }

            foreach (HieraricalViewModel single in collection)
            {
              
                BuildHirarycal(sourceData, response, single, isRecursive, isDirectionDownwards);
            }
        }
    }
}
