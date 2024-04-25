// detail product
document.querySelectorAll('.product-img-item').forEach(e => {
    e.addEventListener('click', () => {
        let img = e.querySelector('img').getAttribute('src')
        document.querySelector('#product-img > img').setAttribute('src', img)
    })
})

document.querySelector('#view-all-desc').addEventListener('click', () => {
    let content = document.querySelector('.product-detail-description-content')
    content.classList.toggle('active')
    document.querySelector('#view-all-desc').innerHTML = content.classList.contains('active') ? 'Thu gọn' : 'Xem thêm'
})





function menuToggle(isHovered) {
    const toggleMenu = document.querySelector('.dropdown-menu-list');
    if (isHovered) {
        toggleMenu.classList.add('active');
    } else {
        toggleMenu.classList.remove('active');
    }
}


