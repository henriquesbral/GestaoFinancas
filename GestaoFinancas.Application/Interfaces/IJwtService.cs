using GestaoFinancas.Domain.Entities;

namespace GestaoFinancas.Application.Interfaces;

public interface IJwtService
{
    (string Token, DateTime ExpiraEm) GerarToken(Usuario usuario);
}