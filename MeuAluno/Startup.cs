using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MeuAlunoRepo;
using MeuAlunoDominio;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MeuAlunoRepo.Services;
using MeuAlunoRepo.Repositories;
using MeuAlunoDominio.Interfaces.Repositories;
using MeuAlunoDominio.Interfaces.Services;

namespace MeuAluno
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMvc().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<MeuAlunoContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDefaultIdentity<UsuarioTokenModelo>()
                .AddEntityFrameworkStores<MeuAlunoContext>()
                .AddDefaultTokenProviders();

            services.AddLogging();
            
            //JWT CONFIGURACAO

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<UsuarioTokenModelo>(appSettingsSection);

            var appSettings = appSettingsSection.Get<UsuarioTokenModelo>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options => 
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = appSettings.Emissor,
                    ValidAudience = appSettings.ValidoEm
                };
            });

            //repositories
            services.AddScoped<IMeuAlunoRepository, MeuAlunoRepository>(); //remover??
            services.AddScoped<IContratoRepository, ContratoRepository>();
            services.AddScoped<IClausulaRepository, ClausulaRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IMateriaRepository, MateriaRepository>();
            services.AddScoped<IAulaRepository, AulaRepository>();
            services.AddScoped<IFinanceiroRepository, FinanceiroRepository>();


            //services
            services.AddScoped<IContratoService, ContratoService>();
            services.AddScoped<IClausulaService, ClausulaService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IMateriaService, MateriaService>();
            services.AddScoped<IAulaService, AulaService>();
            services.AddScoped<IFinanceiroService, FinanceiroService>();

            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

         
            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options =>
            options
            .AllowAnyOrigin()
            .AllowAnyHeader()
           .AllowAnyMethod());

            loggerFactory.CreateLogger<MeuAlunoContext>();

            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });          

        }
    }
}
