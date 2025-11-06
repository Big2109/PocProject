using System.Data;
using Microsoft.EntityFrameworkCore;
using Migrations.Context;
using Migrations.Entities;
using Poc.Repositories.Interfaces;
namespace Poc.Repositories;

public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(Context context) : base(context) { }
    public async Task<Usuario> ObterLogin(Usuario usuario)
    {
        return await _context.Usuario
            .Where(u => u.NomeUsuario == usuario.NomeUsuario
                && u.Senha == usuario.Senha
                || u.NomeUsuario == usuario.NomeUsuario)
            .FirstOrDefaultAsync();
    }
}