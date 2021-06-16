class Pagentaion {
    constructor(length) {
        this.pages = [];
        this.start = 1;
        this.length = length;
    }

    update(currentPage, totalPages) {
        if (currentPage >= this.start + this.length - 1) {
            if (this.start + this.length < totalPages - this.length) {
                this.start += 4;
            }
            else {
                this.start = totalPages - this.length + 1;
            }
        }


        if (currentPage <= this.start) {
            if (this.start - this.length > 1) {
                this.start -= 4;
            }
            else {
                this.start = 1;
            }
        }
    }

    updatePages(currentPage, totalPages)
    {
        this.update(currentPage, totalPages);
        this.pages = [];

        for (let index = this.start; index < this.start + this.length; index++)
        {
            if(index <= totalPages)
                this.pages.push({ number: index, isActive: index === currentPage });        
        }
    }
}