using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 100, "Gabriel García Márquez" },
                    { 101, "Isabel Allende" },
                    { 102, "Mario Vargas Llosa" },
                    { 103, "Jorge Luis Borges" },
                    { 104, "Octavio Paz" },
                    { 105, "Pablo Neruda" },
                    { 106, "Julio Cortázar" },
                    { 107, "Carlos Fuentes" },
                    { 108, "Roberto Bolaño" },
                    { 109, "Laura Esquivel" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "ImageURL", "PagesAmount", "Rating", "Summary", "Title" },
                values: new object[,]
                {
                    { 200, "https://images.cdn1.buscalibre.com/fit-in/360x360/61/8d/618d227e8967274cd9589a549adff52d.jpg", 417, 5, "La historia de la familia Buendía a lo largo de siete generaciones en el pueblo ficticio de Macondo.", "Cien años de soledad" },
                    { 201, "https://images.cdn2.buscalibre.com/fit-in/360x360/c8/fb/c8fb8d4b8c2f4c8a9b1e2d3f4g5h6i7j.jpg", 433, 4, "Una saga familiar que abarca tres generaciones de mujeres en un país latinoamericano.", "La casa de los espíritus" },
                    { 202, "https://images.cdn3.buscalibre.com/fit-in/360x360/d9/gc/d9gc8e5c9d3f5d9b2e4f6h8i0j2k4l6m.jpg", 419, 4, "Una novela sobre la vida en una academia militar en Lima, Perú.", "La ciudad y los perros" },
                    { 203, "https://images.cdn4.buscalibre.com/fit-in/360x360/e0/hd/e0hd9f6d0e4g6e0c3f5h7j9k1l3m5n7o.jpg", 203, 5, "Una colección de cuentos que exploran temas filosóficos y metafísicos.", "El Aleph" },
                    { 204, "https://images.cdn5.buscalibre.com/fit-in/360x360/f1/ie/f1ie0g7e1f5h7f1d4g6i8k0l2m4n6o8p.jpg", 191, 4, "Un ensayo sobre la identidad y psicología del pueblo mexicano.", "El laberinto de la soledad" },
                    { 205, "https://images.cdn6.buscalibre.com/fit-in/360x360/g2/jf/g2jf1h8f2g6i8g2e5h7j9l1m3n5o7p9q.jpg", 96, 5, "Una colección de poemas de amor que captura la pasión y melancolía juvenil.", "Veinte poemas de amor y una canción desesperada" },
                    { 206, "https://images.cdn7.buscalibre.com/fit-in/360x360/h3/kg/h3kg2i9g3h7j9h3f6i8k0m2n4o6p8q0r.jpg", 635, 4, "Una novela experimental que puede leerse de múltiples maneras.", "Rayuela" },
                    { 207, "https://images.cdn8.buscalibre.com/fit-in/360x360/i4/lh/i4lh3j0h4i8k0i4g7j9l1n3o5p7q9r1s.jpg", 307, 4, "La historia de un hombre poderoso en sus últimos momentos de vida.", "La muerte de Artemio Cruz" },
                    { 208, "https://images.cdn9.buscalibre.com/fit-in/360x360/j5/mi/j5mi4k1i5j9l1j5h8k0m2o4p6q8r0s2t.jpg", 609, 4, "Una novela sobre dos jóvenes poetas que buscan a una misteriosa escritora.", "Los detectives salvajes" },
                    { 209, "https://images.cdn10.buscalibre.com/fit-in/360x360/k6/nj/k6nj5l2j6k0m2k6i9l1n3p5q7r9s1t3u.jpg", 246, 4, "Una novela que combina recetas de cocina con una historia de amor prohibido.", "Como agua para chocolate" },
                    { 210, "https://images.cdn11.buscalibre.com/fit-in/360x360/l7/ok/l7ok6m3k7l1n3l7j0m2o4q6r8s0t2u4v.jpg", 368, 5, "Una historia de amor que perdura a través de los años y las circunstancias.", "El amor en los tiempos del cólera" },
                    { 211, "https://images.cdn12.buscalibre.com/fit-in/360x360/m8/pl/m8pl7n4l8m2o4m8k1n3p5r7s9t1u3v5w.jpg", 174, 5, "Una colección de cuentos que exploran laberintos, bibliotecas infinitas y realidades alternativas.", "Ficciones" },
                    { 212, "https://images.cdn13.buscalibre.com/fit-in/360x360/n9/qm/n9qm8o5m9n3p5n9l2o4q6s8t0u2v4w6x.jpg", 447, 4, "Una novela autobiográfica sobre el primer matrimonio del autor.", "La tía Julia y el escribidor" },
                    { 213, "https://images.cdn14.buscalibre.com/fit-in/360x360/o0/rn/o0rn9p6n0o4q6o0m3p5r7t9u1v3w5x7y.jpg", 271, 4, "La historia de una mujer que narra su vida llena de aventuras y desafíos.", "Eva Luna" },
                    { 214, "https://images.cdn15.buscalibre.com/fit-in/360x360/p1/so/p1so0q7o1p5r7p1n4q6s8u0v2w4x6y8z.jpg", 564, 4, "Una novela experimental sobre la búsqueda del amor y el sentido de la vida.", "Hopscotch" },
                    { 215, "https://images.cdn16.buscalibre.com/fit-in/360x360/q2/tp/q2tp1r8p2q6s8q2o5r7t9v1w3x5y7z9a.jpg", 531, 4, "Un extenso poema épico sobre la historia y geografía de América Latina.", "Canto general" },
                    { 216, "https://images.cdn17.buscalibre.com/fit-in/360x360/r3/uq/r3uq2s9q3r7t9r3p6s8u0w2x4y6z8a0b.jpg", 1119, 5, "Una novela póstuma que explora la violencia y el misterio en una ciudad fronteriza.", "2666" },
                    { 217, "https://images.cdn18.buscalibre.com/fit-in/360x360/s4/vr/s4vr3t0r4s8u0s4q7t9v1x3y5z7a9b1c.jpg", 783, 4, "Una novela épica que abarca quinientos años de historia española y americana.", "Terra Nostra" },
                    { 218, "https://images.cdn19.buscalibre.com/fit-in/360x360/t5/ws/t5ws4u1s5t9v1t5r8u0w2y4z6a8b0c2d.jpg", 158, 4, "Una novela psicológica sobre un pintor obsesionado con una mujer.", "El túnel" },
                    { 219, "https://images.cdn20.buscalibre.com/fit-in/360x360/u6/xt/u6xt5v2t6u0w2u6s9v1x3z5a7b9c1d3e.jpg", 124, 5, "Una novela sobre un hombre que busca a su padre en un pueblo fantasmal.", "Pedro Páramo" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthor",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[,]
                {
                    { 100, 200 },
                    { 100, 210 },
                    { 100, 219 },
                    { 101, 201 },
                    { 101, 213 },
                    { 102, 202 },
                    { 102, 212 },
                    { 103, 203 },
                    { 103, 211 },
                    { 103, 218 },
                    { 104, 204 },
                    { 105, 205 },
                    { 105, 215 },
                    { 106, 206 },
                    { 106, 214 },
                    { 107, 207 },
                    { 107, 217 },
                    { 108, 208 },
                    { 108, 216 },
                    { 109, 209 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 100, 200 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 100, 210 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 100, 219 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 101, 201 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 101, 213 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 102, 202 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 102, 212 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 103, 203 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 103, 211 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 103, 218 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 104, 204 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 105, 205 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 105, 215 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 106, 206 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 106, 214 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 107, 207 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 107, 217 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 108, 208 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 108, 216 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 109, 209 });

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 219);
        }
    }
}
