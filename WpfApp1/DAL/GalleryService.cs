using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DAL
{
    public class GalleryService : IGalleryService
    {
        public IEnumerable<PhotoDto> GetGallery(string name)
        {
            return GetDummyData();
        }

        private IEnumerable<PhotoDto> GetDummyData()
        {
            return new List<PhotoDto>()
            {
                new PhotoDto() {Name = "Nature-1", AddedDate = new DateTime(2021, 1, 20, 10, 0, 0), SourceURL = "https://m.economictimes.com/thumb/height-450,width-600,imgsize-1016106,msid-68721417/nature1_gettyimages.jpg" },
                new PhotoDto() {Name = "Nature-2", AddedDate = new DateTime(2021, 1, 15, 12, 0, 0), SourceURL = "https://images.pexels.com/photos/2440061/pexels-photo-2440061.jpeg" },
                new PhotoDto() {Name = "Nature-3", AddedDate = new DateTime(2021, 1, 25, 15, 0, 0), SourceURL = "https://isha.sadhguru.org/blog/wp-content/uploads/2016/05/natures-temples.jpg" },
                new PhotoDto() {Name = "Nature-5", AddedDate = new DateTime(2021, 1, 30, 10, 0, 0), SourceURL = "https://images.pexels.com/photos/3225517/pexels-photo-3225517.jpeg" },

                new PhotoDto() {Name = "Nature-Feb1", AddedDate = new DateTime(2021, 2, 20, 10, 0, 0), SourceURL = "https://m.economictimes.com/thumb/height-450,width-600,imgsize-1016106,msid-68721417/nature1_gettyimages.jpg" },
                new PhotoDto() {Name = "Nature-Feb2", AddedDate = new DateTime(2021, 2, 22, 10, 0, 0), SourceURL = "https://images.pexels.com/photos/2440061/pexels-photo-2440061.jpeg" },
                new PhotoDto() {Name = "Nature-Feb3", AddedDate = new DateTime(2021, 2, 5, 10, 0, 0), SourceURL = "https://isha.sadhguru.org/blog/wp-content/uploads/2016/05/natures-temples.jpg" },
                new PhotoDto() {Name = "Nature-Feb5", AddedDate = new DateTime(2021, 2, 2, 10, 0, 0), SourceURL = "https://images.pexels.com/photos/3225517/pexels-photo-3225517.jpeg" }
            };
        }
    }
}
