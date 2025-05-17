using Auditorias.Aplicacion.Dto;
using Auditorias.Dominio.Entidades;
using AutoMapper;

namespace Auditorias.Aplicacion.Mapeadores
{
    public class AuditoriaMapeador: Profile
    {
        public AuditoriaMapeador()
        {
            CreateMap<Auditoria, AuditoriaDto>()
                .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(src => src.IdUsuario))
                .ForMember(dest => dest.Accion, opt => opt.MapFrom(src => src.Accion))
                .ForMember(dest => dest.TablaAfectada, opt => opt.MapFrom(src => src.TablaAfectada))
                .ForMember(dest => dest.Idregistro, opt => opt.MapFrom(src => src.Idregistro))
                .ForMember(dest => dest.Registro, opt => opt.MapFrom(src => src.Registro))
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.FechaCreacion))
                .ReverseMap();

            CreateMap<Auditoria, AuditoriaIn>()
                .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(src => src.IdUsuario))
                .ForMember(dest => dest.Accion, opt => opt.MapFrom(src => src.Accion))
                .ForMember(dest => dest.TablaAfectada, opt => opt.MapFrom(src => src.TablaAfectada))
                .ForMember(dest => dest.Idregistro, opt => opt.MapFrom(src => src.Idregistro))
                .ForMember(dest => dest.Registro, opt => opt.MapFrom(src => src.Registro))
                .ReverseMap();

            CreateMap<AuditoriaOut, AuditoriaIn>()
                .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(src => src.Auditoria.IdUsuario))
                .ForMember(dest => dest.Accion, opt => opt.MapFrom(src => src.Auditoria.Accion))
                .ForMember(dest => dest.TablaAfectada, opt => opt.MapFrom(src => src.Auditoria.TablaAfectada))
                .ForMember(dest => dest.Idregistro, opt => opt.MapFrom(src => src.Auditoria.Idregistro))
                .ForMember(dest => dest.Registro, opt => opt.MapFrom(src => src.Auditoria.Registro))
                .ReverseMap();
        }
    }
}
