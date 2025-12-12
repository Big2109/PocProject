using Poc.Models;
using Poc.ViewModels;

namespace Poc.Services.Interfaces;

public interface IResumoService
{
    Task<ResumoViewModel> CalcularTotais();
}