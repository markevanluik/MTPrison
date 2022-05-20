using MTPrison.Data;
using MTPrison.Domain;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MTPrison.Tests.MTPrisonApp {

    public abstract class BasePageTests : HostTests { // base for clean-code/tests
        public static async Task GetIndexPageTest<TRepo, TEntity, TData>(string name, Func<TData, TEntity> toObj, string? id = null, TRepo? r = null)
            where TRepo : class, IRepo<TEntity>
            where TEntity : UniqueEntity {
            _ = addRandomItems(out int cnt, toObj, id, r);
            var page = await client.GetAsync($"/{name}?handler=Index");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains($"<h1>{name}</h1>")); // >Log in< if [Authorize] is active
        }
        public static async Task<(TData, string)> GetEditPageTest<TRepo, TEntity, TData>(string name, Func<TData, TEntity> toObj, TRepo? r = null)
            where TRepo : class, IRepo<TEntity>
            where TEntity : UniqueEntity {
            var id = UniqueData.NewId[..10];
            var d = addRandomItems(out int cnt, toObj, id, r);
            isNotNull(d);
            var page = await client.GetAsync($"/{name}/Edit?handler=Edit&id={id}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains($"<h1>Edit</h1>"));
            return (d, html);
        }
        public static async Task<(TData, string)> GetDetailsPageTest<TRepo, TEntity, TData>(string name, Func<TData, TEntity> toObj, TRepo? r = null)
            where TRepo : class, IRepo<TEntity>
            where TEntity : UniqueEntity {
            var id = UniqueData.NewId[..10];
            var d = addRandomItems(out int cnt, toObj, id, r);
            isNotNull(d);
            var page = await client.GetAsync($"/{name}/Details?handler=Details&id={id}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains($"<h1>Details</h1>"));
            return (d, html);
        }
        public static async Task<(TData, string)> GetDeletePageTest<TRepo, TEntity, TData>(string name, Func<TData, TEntity> toObj, TRepo? r = null)
            where TRepo : class, IRepo<TEntity>
            where TEntity : UniqueEntity {
            var id = UniqueData.NewId[..10];
            var d = addRandomItems(out int cnt, toObj, id, r);
            isNotNull(d);
            var page = await client.GetAsync($"/{name}/Delete?handler=Delete&id={id}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains($"<h1>Delete</h1>"));
            return (d, html);
        }
        public static async Task<(TData, string)> GetCreatePageTest<TRepo, TEntity, TData>(string name, Func<TData, TEntity> toObj, string? id = null, TRepo? r = null)
            where TRepo : class, IRepo<TEntity>
            where TEntity : UniqueEntity {
            var d = addRandomItems(out int cnt, toObj, id, r);
            isNotNull(d);
            var page = await client.GetAsync($"/{name}/Create?idx=0&handler=Create");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains($"<h1>Create</h1>"));
            return (d, html);
        }
    }
}
