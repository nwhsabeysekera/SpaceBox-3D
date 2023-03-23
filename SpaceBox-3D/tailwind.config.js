/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './**/*.aspx',
        './**/*.Master',
    ],
    theme: {
    extend: {},
    },
    plugins: [
        require('@tailwindcss/forms'),
        require('@tailwindcss/typography'),
    ],
}
