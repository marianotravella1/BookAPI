using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageURLsToLocal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Update existing book image URLs to use local placeholder images
            migrationBuilder.Sql("UPDATE Books SET ImageURL = '/book-cover-1.svg' WHERE Id = 200;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = '/book-cover-2.svg' WHERE Id = 201;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = '/book-cover-3.svg' WHERE Id = 202;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = '/book-cover-4.svg' WHERE Id = 203;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = '/book-cover-5.svg' WHERE Id = 204;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = '/book-cover-1.svg' WHERE Id = 205;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = '/book-cover-2.svg' WHERE Id = 206;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = '/book-cover-3.svg' WHERE Id = 207;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = '/book-cover-4.svg' WHERE Id = 208;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = '/book-cover-5.svg' WHERE Id = 209;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = '/book-cover-1.svg' WHERE Id = 210;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = '/book-cover-2.svg' WHERE Id = 211;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = '/book-cover-3.svg' WHERE Id = 212;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = '/book-cover-4.svg' WHERE Id = 213;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = '/book-cover-5.svg' WHERE Id = 214;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = '/book-cover-1.svg' WHERE Id = 215;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = '/book-cover-2.svg' WHERE Id = 216;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = '/book-cover-3.svg' WHERE Id = 217;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = '/book-cover-4.svg' WHERE Id = 218;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = '/book-cover-5.svg' WHERE Id = 219;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert to original external URLs
            migrationBuilder.Sql("UPDATE Books SET ImageURL = 'https://images.cdn1.buscalibre.com/fit-in/360x360/61/8d/618d227e8967274cd9589a549adff52d.jpg' WHERE Id = 200;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = 'https://images.cdn2.buscalibre.com/fit-in/360x360/c8/fb/c8fb8d4b8c2f4c8a9b1e2d3f4g5h6i7j.jpg' WHERE Id = 201;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = 'https://images.cdn3.buscalibre.com/fit-in/360x360/d9/gc/d9gc8e5c9d3f5d9b2e4f6h8i0j2k4l6m.jpg' WHERE Id = 202;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = 'https://images.cdn4.buscalibre.com/fit-in/360x360/e0/hd/e0hd9f6d0e4g6e0c3f5h7j9k1l3m5n7o.jpg' WHERE Id = 203;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = 'https://images.cdn5.buscalibre.com/fit-in/360x360/f1/ie/f1ie0g7e1f5h7f1d4g6i8k0l2m4n6o8p.jpg' WHERE Id = 204;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = 'https://images.cdn6.buscalibre.com/fit-in/360x360/g2/jf/g2jf1h8f2g6i8g2e5h7j9l1m3n5o7p9q.jpg' WHERE Id = 205;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = 'https://images.cdn7.buscalibre.com/fit-in/360x360/h3/kg/h3kg2i9g3h7j9h3f6i8k0m2n4o6p8q0r.jpg' WHERE Id = 206;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = 'https://images.cdn8.buscalibre.com/fit-in/360x360/i4/lh/i4lh3j0h4i8k0i4g7j9l1n3o5p7q9r1s.jpg' WHERE Id = 207;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = 'https://images.cdn9.buscalibre.com/fit-in/360x360/j5/mi/j5mi4k1i5j9l1j5h8k0m2o4p6q8r0s2t.jpg' WHERE Id = 208;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = 'https://images.cdn10.buscalibre.com/fit-in/360x360/k6/nj/k6nj5l2j6k0m2k6i9l1n3p5q7r9s1t3u.jpg' WHERE Id = 209;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = 'https://images.cdn11.buscalibre.com/fit-in/360x360/l7/ok/l7ok6m3k7l1n3l7j0m2o4q6r8s0t2u4v.jpg' WHERE Id = 210;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = 'https://images.cdn12.buscalibre.com/fit-in/360x360/m8/pl/m8pl7n4l8m2o4m8k1n3p5r7s9t1u3v5w.jpg' WHERE Id = 211;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = 'https://images.cdn13.buscalibre.com/fit-in/360x360/n9/qm/n9qm8o5m9n3p5n9l2o4q6s8t0u2v4w6x.jpg' WHERE Id = 212;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = 'https://images.cdn14.buscalibre.com/fit-in/360x360/o0/rn/o0rn9p6n0o4q6o0m3p5r7t9u1v3w5x7y.jpg' WHERE Id = 213;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = 'https://images.cdn15.buscalibre.com/fit-in/360x360/p1/so/p1so0q7o1p5r7p1n4q6s8u0v2w4x6y8z.jpg' WHERE Id = 214;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = 'https://images.cdn16.buscalibre.com/fit-in/360x360/q2/tp/q2tp1r8p2q6s8q2o5r7t9v1w3x5y7z9a.jpg' WHERE Id = 215;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = 'https://images.cdn17.buscalibre.com/fit-in/360x360/r3/uq/r3uq2s9q3r7t9r3p6s8u0w2x4y6z8a0b.jpg' WHERE Id = 216;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = 'https://images.cdn18.buscalibre.com/fit-in/360x360/s4/vr/s4vr3t0r4s8u0s4q7t9v1x3y5z7a9b1c.jpg' WHERE Id = 217;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = 'https://images.cdn19.buscalibre.com/fit-in/360x360/t5/ws/t5ws4u1s5t9v1t5r8u0w2y4z6a8b0c2d.jpg' WHERE Id = 218;");
            migrationBuilder.Sql("UPDATE Books SET ImageURL = 'https://images.cdn20.buscalibre.com/fit-in/360x360/u6/xt/u6xt5v2t6u0w2u6s9v1x3z5a7b9c1d3e.jpg' WHERE Id = 219;");
        }
    }
}
