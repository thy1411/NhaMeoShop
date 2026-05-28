using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NhaMeoShop.Models;

namespace NhaMeoShop.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser>
            _signInManager;

        private readonly UserManager<IdentityUser>
            _userManager;

        private readonly ILogger<RegisterModel>
            _logger;

        private readonly AppDbContext
            _context;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            AppDbContext context)
        {
            _userManager = userManager;

            _signInManager = signInManager;

            _logger = logger;

            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme>
            ExternalLogins
        { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage =
                "Vui lòng nhập tên khách hàng")]
            public string TenKH { get; set; }

            [DataType(DataType.Date)]
            public DateTime NgaySinhKH { get; set; }

            public string SoDTKH { get; set; }

            public string GhiChuKH { get; set; }

            [Required(ErrorMessage =
                "Vui lòng chọn loại tài khoản")]
            public string Role { get; set; }

            [Required(ErrorMessage =
                "Vui lòng nhập email")]

            [EmailAddress]
            public string Email { get; set; }

            [Required(ErrorMessage =
                "Vui lòng nhập mật khẩu")]

            [StringLength(100,
                ErrorMessage =
                "Mật khẩu phải ít nhất {2} ký tự.",
                MinimumLength = 6)]

            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required(ErrorMessage =
                "Vui lòng xác nhận mật khẩu")]

            [DataType(DataType.Password)]

            [Compare("Password",
                ErrorMessage =
                "Mật khẩu xác nhận không khớp")]

            public string ConfirmPassword
            {
                get;
                set;
            }
        }

        public async Task OnGetAsync(
            string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            ExternalLogins =
                (await _signInManager
                .GetExternalAuthenticationSchemesAsync())
                .ToList();
        }

        public async Task<IActionResult>
            OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins =
                (await _signInManager
                .GetExternalAuthenticationSchemesAsync())
                .ToList();

            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = Input.Email,

                    Email = Input.Email
                };

                var result =
                    await _userManager.CreateAsync(
                        user,
                        Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation(
                        "Đăng ký tài khoản thành công.");

                    // GÁN ROLE
                    await _userManager
                        .AddToRoleAsync(
                            user,
                            Input.Role);

                    // LƯU KHÁCH HÀNG
                    // TẠO MÃ KHÁCH HÀNG TỰ ĐỘNG
                    var khCuoi = _context.KhachHangs
                        .OrderByDescending(x => x.MaKH)
                        .FirstOrDefault();

                    int soMoi = 1;

                    if (khCuoi != null)
                    {
                        string soCu = khCuoi.MaKH.Substring(2);

                        soMoi = int.Parse(soCu) + 1;
                    }

                    string maKH =
                        "KH" + soMoi.ToString("D3");

                    // LƯU KHÁCH HÀNG
                    var kh = new KhachHang
                    {
                        MaKH = maKH,

                        TenKH = Input.TenKH,

                        NgaySinhKH = Input.NgaySinhKH,

                        SoDTKH = Input.SoDTKH,

                        NgayDKTV = DateTime.Now,

                        Email = Input.Email,

                        Password = Input.Password,

                        GhiChuKH = Input.GhiChuKH,

                        MaLoaiKH = "TV",

                        UserId = user.Id
                    };

                    _context.KhachHangs.Add(kh);

                    await _context.SaveChangesAsync();
                    // LOGIN
                    await _signInManager
                        .SignInAsync(
                            user,
                            isPersistent: false);

                    return RedirectToAction(
                        "Index",
                        "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(
                        string.Empty,
                        error.Description);
                }
            }

            return Page();
        }
    }
}