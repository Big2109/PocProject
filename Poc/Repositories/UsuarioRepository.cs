using System.Data;
using Microsoft.EntityFrameworkCore;
using Migrations.Context;
using Migrations.Entities;
using Poc.Repositories.Interfaces;
namespace Poc.Repositories;

public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(Context context) : base(context) { }
    public async Task<Usuario> ObterPorNomeUsuario(string nomeUsuario)
    {
        return await _context.Usuario
            .Where(u => u.NomeUsuario == nomeUsuario)
            .FirstOrDefaultAsync();
    }
    public async Task<Usuario> ObterPorNomeUsuarioESenha(Usuario usuario)
    {
        return await _context.Usuario
            .Where(u => u.NomeUsuario == usuario.NomeUsuario
                 && u.Senha == usuario.Senha
                    || u.Email == usuario.NomeUsuario
                        && u.Senha == usuario.Senha
                )
            .FirstOrDefaultAsync();
    }
}