/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './**/*.aspx',
        './**/*.Master',
    ],
    theme: {
        extend: {
            colors: {
                'maincolor': '#2F2F2F',
                'primary-grey': '#3B3B3B',
                'secondary-grey': '#686868',
                'primary-yellow': '#FFCB74',
                'h1-color': '#E6A02D',
            },
            fontFamily: {
                'readex': ['Readex Pro', 'sans-serif'],
            }
        },
    },
    plugins: [
        require('@tailwindcss/forms'),
        require('@tailwindcss/typography'),
    ],
}
