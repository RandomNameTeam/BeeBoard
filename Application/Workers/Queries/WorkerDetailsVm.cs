using Application.Common.Mappings;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Workers.Queries
{
    internal class WorkerDetailsVm: IMapWith<Worker>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Worker, WorkerDetailsVm>()
                .ForMember(workerVm => workerVm.Id,
                    opt => opt.MapFrom(worker => worker.Id))
                .ForMember(workerVm => workerVm.UserId,
                    opt => opt.MapFrom(worker => worker.User.Id))
                .ForMember(workerVm => workerVm.Description,
                    opt => opt.MapFrom(worker => worker.Description));
        }
    }
}
