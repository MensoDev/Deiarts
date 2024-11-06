/** @type {import('tailwindcss').Config} */
module.exports = {
    prefix: 'tw|',
    content: ["**/*.razor", "**/*.cshtml", "**/*.html"],
    // Evita reset (@base),para estragar bordas de web components fluent
    corePlugins: {
        preflight: false,
    }
}