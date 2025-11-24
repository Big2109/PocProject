# 🌐 Poc

Um projeto **ASP.NET Core MVC** desenvolvido para servir como **portfólio pessoal**, com integração a um **banco de dados SQL Server** em container Docker.  
O objetivo é demonstrar habilidades em desenvolvimento web utilizando **.NET 8+, Entity Framework Core** e boas práticas de arquitetura MVC.

---

## 🚀 Tecnologias Utilizadas
🖥️ Back-end

- **.NET 8.0 — framework principal da aplicação**
- **ASP.NET Core MVC — arquitetura Model-View-Controller**
- **Entity Framework Core — ORM para acesso e persistência de dados**
- **SQL Server (Docker) — banco de dados containerizado para ambiente local**
- **Dependency Injection (DI) — para gerenciamento de dependências**
- **LINQ — consultas fortemente tipadas e integração com EF Core**

🎨 Front-end

- **Bootstrap 5 — estilização responsiva e componentes prontos**
- **jQuery — manipulação de DOM e suporte a plugins**
- **jQuery Validation / Unobtrusive Validation — validações client-side integradas às Views**
- **Razor (CSHTML) — renderização dinâmica de páginas**

---

## 🏗️ Estrutura do Projeto

<!-- BEGIN STRUCTURE -->
```
.
|-- appsettings.Development.json
|-- appsettings.json
|-- AutoMapper
|   `-- PocProfile.cs
|-- Controllers
|   |-- BaseController.cs
|   |-- ConfiguracaoController.cs
|   |-- HomeController.cs
|   |-- LoginController.cs
|   `-- PocController.cs
|-- Docker
|-- Enums
|   `-- Messages.cs
|-- Extensions
|   |-- ServiceCollectionExtensions.cs
|   |-- UserSessionHelper.cs
|   |-- WebApplicationBuilderExtensions.cs
|   `-- WebApplicattionExtensions.cs
|-- LICENSE
|-- Models
|   |-- AcessoModel.cs
|   |-- ClienteModel.cs
|   |-- ErrorViewModel.cs
|   |-- UsuarioModel.cs
|   `-- ValidacaoModel.cs
|-- package.json
|-- Poc.csproj
|-- Program.cs
|-- Properties
|   `-- launchSettings.json
|-- Repositories
|   |-- AcessoRepository.cs
|   |-- BaseRepository.cs
|   |-- ClienteRepository.cs
|   |-- Interfaces
|   |   |-- IAcessoRepository.cs
|   |   |-- IBaseRepository.cs
|   |   |-- IClienteRepository.cs
|   |   `-- IUsuarioRepository.cs
|   `-- UsuarioRepository.cs
|-- Services
|   |-- AcessoService.cs
|   |-- BaseService.cs
|   |-- ClienteService.cs
|   |-- Interfaces
|   |   |-- IAcessoService.cs
|   |   |-- IBaseService.cs
|   |   |-- IClienteService.cs
|   |   |-- IUsuarioService.cs
|   |   `-- IValidacaoService.cs
|   |-- UsuarioService.cs
|   `-- ValidacaoService.cs
|-- Settings
|   `-- AppSettings.cs
|-- SQL
|   |-- docker-compose.yml
|   |-- Poc
|   |   |-- Procedures
|   |   `-- Tables
|   |       |-- Acesso.sql
|   |       |-- Cliente.sql
|   |       `-- Usuario.sql
|   `-- Poc.bak
|-- update-readme.sh
|-- ViewModels
|   `-- UsuariosViewModel.cs
|-- Views
|   |-- Configuracao
|   |   `-- Usuarios.cshtml
|   |-- Home
|   |   |-- Index.cshtml
|   |   `-- Privacy.cshtml
|   |-- Login
|   |   |-- Index.cshtml
|   |   `-- Registrar.cshtml
|   |-- Poc
|   |   |-- Dashboard.cshtml
|   |   `-- Index.cshtml
|   |-- Shared
|   |   |-- Error.cshtml
|   |   |-- _FeedbackModal.cshtml
|   |   |-- _Layout.cshtml
|   |   |-- _Menu.cshtml
|   |   |-- _NovoUsuario.cshtml
|   |   `-- _ValidationScriptsPartial.cshtml
|   |-- _ViewImports.cshtml
|   `-- _ViewStart.cshtml
`-- wwwroot
    |-- css
    |   `-- styles.css
    |-- favicon.ico
    |-- img
    |   `-- logo
    |       |-- logo_poc.svg
    |       `-- poc_logo.svg
    |-- js
    |   `-- Vue
    |       |-- Configuracao
    |       |   `-- usuarios.js
    |       |-- main.js
    |       |-- Modal
    |       |   `-- feedback.js
    |       `-- Poc
    |           |-- index.js
    |           `-- menu.js
    |-- lib
    |   |-- bootstrap
    |   |   |-- dist
    |   |   |   |-- css
    |   |   |   |   |-- bootstrap.css
    |   |   |   |   |-- bootstrap.css.map
    |   |   |   |   |-- bootstrap-grid.css
    |   |   |   |   |-- bootstrap-grid.css.map
    |   |   |   |   |-- bootstrap-grid.min.css
    |   |   |   |   |-- bootstrap-grid.min.css.map
    |   |   |   |   |-- bootstrap-grid.rtl.css
    |   |   |   |   |-- bootstrap-grid.rtl.css.map
    |   |   |   |   |-- bootstrap-grid.rtl.min.css
    |   |   |   |   |-- bootstrap-grid.rtl.min.css.map
    |   |   |   |   |-- bootstrap.min.css
    |   |   |   |   |-- bootstrap.min.css.map
    |   |   |   |   |-- bootstrap-reboot.css
    |   |   |   |   |-- bootstrap-reboot.css.map
    |   |   |   |   |-- bootstrap-reboot.min.css
    |   |   |   |   |-- bootstrap-reboot.min.css.map
    |   |   |   |   |-- bootstrap-reboot.rtl.css
    |   |   |   |   |-- bootstrap-reboot.rtl.css.map
    |   |   |   |   |-- bootstrap-reboot.rtl.min.css
    |   |   |   |   |-- bootstrap-reboot.rtl.min.css.map
    |   |   |   |   |-- bootstrap.rtl.css
    |   |   |   |   |-- bootstrap.rtl.css.map
    |   |   |   |   |-- bootstrap.rtl.min.css
    |   |   |   |   |-- bootstrap.rtl.min.css.map
    |   |   |   |   |-- bootstrap-utilities.css
    |   |   |   |   |-- bootstrap-utilities.css.map
    |   |   |   |   |-- bootstrap-utilities.min.css
    |   |   |   |   |-- bootstrap-utilities.min.css.map
    |   |   |   |   |-- bootstrap-utilities.rtl.css
    |   |   |   |   |-- bootstrap-utilities.rtl.css.map
    |   |   |   |   |-- bootstrap-utilities.rtl.min.css
    |   |   |   |   `-- bootstrap-utilities.rtl.min.css.map
    |   |   |   `-- js
    |   |   |       |-- bootstrap.bundle.js
    |   |   |       |-- bootstrap.bundle.js.map
    |   |   |       |-- bootstrap.bundle.min.js
    |   |   |       |-- bootstrap.bundle.min.js.map
    |   |   |       |-- bootstrap.esm.js
    |   |   |       |-- bootstrap.esm.js.map
    |   |   |       |-- bootstrap.esm.min.js
    |   |   |       |-- bootstrap.esm.min.js.map
    |   |   |       |-- bootstrap.js
    |   |   |       |-- bootstrap.js.map
    |   |   |       |-- bootstrap.min.js
    |   |   |       `-- bootstrap.min.js.map
    |   |   `-- LICENSE
    |   |-- jquery
    |   |   |-- dist
    |   |   |   |-- jquery.js
    |   |   |   |-- jquery.min.js
    |   |   |   |-- jquery.min.map
    |   |   |   |-- jquery.slim.js
    |   |   |   |-- jquery.slim.min.js
    |   |   |   `-- jquery.slim.min.map
    |   |   `-- LICENSE.txt
    |   |-- jquery-validation
    |   |   |-- dist
    |   |   |   |-- additional-methods.js
    |   |   |   |-- additional-methods.min.js
    |   |   |   |-- jquery.validate.js
    |   |   |   `-- jquery.validate.min.js
    |   |   `-- LICENSE.md
    |   `-- jquery-validation-unobtrusive
    |       |-- dist
    |       |   |-- jquery.validate.unobtrusive.js
    |       |   `-- jquery.validate.unobtrusive.min.js
    |       `-- LICENSE.txt
    |-- node_modules
    |   |-- autoprefixer
    |   |   |-- data
    |   |   |   `-- prefixes.js
    |   |   |-- lib
    |   |   |   |-- at-rule.js
    |   |   |   |-- autoprefixer.d.ts
    |   |   |   |-- autoprefixer.js
    |   |   |   |-- brackets.js
    |   |   |   |-- browsers.js
    |   |   |   |-- declaration.js
    |   |   |   |-- hacks
    |   |   |   |   |-- align-content.js
    |   |   |   |   |-- align-items.js
    |   |   |   |   |-- align-self.js
    |   |   |   |   |-- animation.js
    |   |   |   |   |-- appearance.js
    |   |   |   |   |-- autofill.js
    |   |   |   |   |-- backdrop-filter.js
    |   |   |   |   |-- background-clip.js
    |   |   |   |   |-- background-size.js
    |   |   |   |   |-- block-logical.js
    |   |   |   |   |-- border-image.js
    |   |   |   |   |-- border-radius.js
    |   |   |   |   |-- break-props.js
    |   |   |   |   |-- cross-fade.js
    |   |   |   |   |-- display-flex.js
    |   |   |   |   |-- display-grid.js
    |   |   |   |   |-- file-selector-button.js
    |   |   |   |   |-- filter.js
    |   |   |   |   |-- filter-value.js
    |   |   |   |   |-- flex-basis.js
    |   |   |   |   |-- flex-direction.js
    |   |   |   |   |-- flex-flow.js
    |   |   |   |   |-- flex-grow.js
    |   |   |   |   |-- flex.js
    |   |   |   |   |-- flex-shrink.js
    |   |   |   |   |-- flex-spec.js
    |   |   |   |   |-- flex-wrap.js
    |   |   |   |   |-- fullscreen.js
    |   |   |   |   |-- gradient.js
    |   |   |   |   |-- grid-area.js
    |   |   |   |   |-- grid-column-align.js
    |   |   |   |   |-- grid-end.js
    |   |   |   |   |-- grid-row-align.js
    |   |   |   |   |-- grid-row-column.js
    |   |   |   |   |-- grid-rows-columns.js
    |   |   |   |   |-- grid-start.js
    |   |   |   |   |-- grid-template-areas.js
    |   |   |   |   |-- grid-template.js
    |   |   |   |   |-- grid-utils.js
    |   |   |   |   |-- image-rendering.js
    |   |   |   |   |-- image-set.js
    |   |   |   |   |-- inline-logical.js
    |   |   |   |   |-- intrinsic.js
    |   |   |   |   |-- justify-content.js
    |   |   |   |   |-- mask-border.js
    |   |   |   |   |-- mask-composite.js
    |   |   |   |   |-- order.js
    |   |   |   |   |-- overscroll-behavior.js
    |   |   |   |   |-- pixelated.js
    |   |   |   |   |-- placeholder.js
    |   |   |   |   |-- placeholder-shown.js
    |   |   |   |   |-- place-self.js
    |   |   |   |   |-- print-color-adjust.js
    |   |   |   |   |-- text-decoration.js
    |   |   |   |   |-- text-decoration-skip-ink.js
    |   |   |   |   |-- text-emphasis-position.js
    |   |   |   |   |-- transform-decl.js
    |   |   |   |   |-- user-select.js
    |   |   |   |   `-- writing-mode.js
    |   |   |   |-- info.js
    |   |   |   |-- old-selector.js
    |   |   |   |-- old-value.js
    |   |   |   |-- prefixer.js
    |   |   |   |-- prefixes.js
    |   |   |   |-- processor.js
    |   |   |   |-- resolution.js
    |   |   |   |-- selector.js
    |   |   |   |-- supports.js
    |   |   |   |-- transition.js
    |   |   |   |-- utils.js
    |   |   |   |-- value.js
    |   |   |   `-- vendor.js
    |   |   |-- LICENSE
    |   |   `-- package.json
    |   |-- baseline-browser-mapping
    |   |   |-- dist
    |   |   |   |-- cli.js
    |   |   |   |-- index.cjs
    |   |   |   |-- index.d.ts
    |   |   |   `-- index.js
    |   |   |-- LICENSE.txt
    |   |   `-- package.json
    |   |-- .bin
    |   |   |-- autoprefixer -> ../autoprefixer/bin/autoprefixer
    |   |   |-- baseline-browser-mapping -> ../baseline-browser-mapping/dist/cli.js
    |   |   |-- browserslist -> ../browserslist/cli.js
    |   |   |-- nanoid -> ../nanoid/bin/nanoid.cjs
    |   |   `-- update-browserslist-db -> ../update-browserslist-db/cli.js
    |   |-- browserslist
    |   |   |-- browser.js
    |   |   |-- cli.js
    |   |   |-- error.d.ts
    |   |   |-- error.js
    |   |   |-- index.d.ts
    |   |   |-- index.js
    |   |   |-- LICENSE
    |   |   |-- node.js
    |   |   |-- package.json
    |   |   `-- parse.js
    |   |-- caniuse-lite
    |   |   |-- data
    |   |   |   |-- agents.js
    |   |   |   |-- browsers.js
    |   |   |   |-- browserVersions.js
    |   |   |   |-- features
    |   |   |   |   |-- aac.js
    |   |   |   |   |-- abortcontroller.js
    |   |   |   |   |-- ac3-ec3.js
    |   |   |   |   |-- accelerometer.js
    |   |   |   |   |-- addeventlistener.js
    |   |   |   |   |-- alternate-stylesheet.js
    |   |   |   |   |-- ambient-light.js
    |   |   |   |   |-- apng.js
    |   |   |   |   |-- array-find-index.js
    |   |   |   |   |-- array-find.js
    |   |   |   |   |-- array-flat.js
    |   |   |   |   |-- array-includes.js
    |   |   |   |   |-- arrow-functions.js
    |   |   |   |   |-- asmjs.js
    |   |   |   |   |-- async-clipboard.js
    |   |   |   |   |-- async-functions.js
    |   |   |   |   |-- atob-btoa.js
    |   |   |   |   |-- audio-api.js
    |   |   |   |   |-- audio.js
    |   |   |   |   |-- audiotracks.js
    |   |   |   |   |-- autofocus.js
    |   |   |   |   |-- auxclick.js
    |   |   |   |   |-- av1.js
    |   |   |   |   |-- avif.js
    |   |   |   |   |-- background-attachment.js
    |   |   |   |   |-- background-clip-text.js
    |   |   |   |   |-- background-img-opts.js
    |   |   |   |   |-- background-position-x-y.js
    |   |   |   |   |-- background-repeat-round-space.js
    |   |   |   |   |-- background-sync.js
    |   |   |   |   |-- battery-status.js
    |   |   |   |   |-- beacon.js
    |   |   |   |   |-- beforeafterprint.js
    |   |   |   |   |-- bigint.js
    |   |   |   |   |-- blobbuilder.js
    |   |   |   |   |-- bloburls.js
    |   |   |   |   |-- border-image.js
    |   |   |   |   |-- border-radius.js
    |   |   |   |   |-- broadcastchannel.js
    |   |   |   |   |-- brotli.js
    |   |   |   |   |-- calc.js
    |   |   |   |   |-- canvas-blending.js
    |   |   |   |   |-- canvas.js
    |   |   |   |   |-- canvas-text.js
    |   |   |   |   |-- chacha20-poly1305.js
    |   |   |   |   |-- channel-messaging.js
    |   |   |   |   |-- childnode-remove.js
    |   |   |   |   |-- ch-unit.js
    |   |   |   |   |-- classlist.js
    |   |   |   |   |-- client-hints-dpr-width-viewport.js
    |   |   |   |   |-- clipboard.js
    |   |   |   |   |-- colr.js
    |   |   |   |   |-- colr-v1.js
    |   |   |   |   |-- comparedocumentposition.js
    |   |   |   |   |-- console-basic.js
    |   |   |   |   |-- console-time.js
    |   |   |   |   |-- const.js
    |   |   |   |   |-- constraint-validation.js
    |   |   |   |   |-- contenteditable.js
    |   |   |   |   |-- contentsecuritypolicy2.js
    |   |   |   |   |-- contentsecuritypolicy.js
    |   |   |   |   |-- cookie-store-api.js
    |   |   |   |   |-- cors.js
    |   |   |   |   |-- createimagebitmap.js
    |   |   |   |   |-- credential-management.js
    |   |   |   |   |-- cross-document-view-transitions.js
    |   |   |   |   |-- cryptography.js
    |   |   |   |   |-- css3-attr.js
    |   |   |   |   |-- css3-boxsizing.js
    |   |   |   |   |-- css3-colors.js
    |   |   |   |   |-- css3-cursors-grab.js
    |   |   |   |   |-- css3-cursors.js
    |   |   |   |   |-- css3-cursors-newer.js
    |   |   |   |   |-- css3-tabsize.js
    |   |   |   |   |-- css-all.js
    |   |   |   |   |-- css-anchor-positioning.js
    |   |   |   |   |-- css-animation.js
    |   |   |   |   |-- css-any-link.js
    |   |   |   |   |-- css-appearance.js
    |   |   |   |   |-- css-at-counter-style.js
    |   |   |   |   |-- css-autofill.js
    |   |   |   |   |-- css-backdrop-filter.js
    |   |   |   |   |-- css-backgroundblendmode.js
    |   |   |   |   |-- css-background-offsets.js
    |   |   |   |   |-- css-boxdecorationbreak.js
    |   |   |   |   |-- css-boxshadow.js
    |   |   |   |   |-- css-canvas.js
    |   |   |   |   |-- css-caret-color.js
    |   |   |   |   |-- css-cascade-layers.js
    |   |   |   |   |-- css-cascade-scope.js
    |   |   |   |   |-- css-case-insensitive.js
    |   |   |   |   |-- css-clip-path.js
    |   |   |   |   |-- css-color-adjust.js
    |   |   |   |   |-- css-color-function.js
    |   |   |   |   |-- css-conic-gradients.js
    |   |   |   |   |-- css-container-queries.js
    |   |   |   |   |-- css-container-queries-style.js
    |   |   |   |   |-- css-container-query-units.js
    |   |   |   |   |-- css-containment.js
    |   |   |   |   |-- css-content-visibility.js
    |   |   |   |   |-- css-counters.js
    |   |   |   |   |-- css-crisp-edges.js
    |   |   |   |   |-- css-cross-fade.js
    |   |   |   |   |-- css-default-pseudo.js
    |   |   |   |   |-- css-descendant-gtgt.js
    |   |   |   |   |-- css-deviceadaptation.js
    |   |   |   |   |-- css-dir-pseudo.js
    |   |   |   |   |-- css-display-contents.js
    |   |   |   |   |-- css-element-function.js
    |   |   |   |   |-- css-env-function.js
    |   |   |   |   |-- css-exclusions.js
    |   |   |   |   |-- css-featurequeries.js
    |   |   |   |   |-- css-file-selector-button.js
    |   |   |   |   |-- css-filter-function.js
    |   |   |   |   |-- css-filters.js
    |   |   |   |   |-- css-first-letter.js
    |   |   |   |   |-- css-first-line.js
    |   |   |   |   |-- css-fixed.js
    |   |   |   |   |-- css-focus-visible.js
    |   |   |   |   |-- css-focus-within.js
    |   |   |   |   |-- css-font-palette.js
    |   |   |   |   |-- css-font-rendering-controls.js
    |   |   |   |   |-- css-font-stretch.js
    |   |   |   |   |-- css-gencontent.js
    |   |   |   |   |-- css-gradients.js
    |   |   |   |   |-- css-grid-animation.js
    |   |   |   |   |-- css-grid.js
    |   |   |   |   |-- css-hanging-punctuation.js
    |   |   |   |   |-- css-has.js
    |   |   |   |   |-- css-hyphens.js
    |   |   |   |   |-- css-if.js
    |   |   |   |   |-- css-image-orientation.js
    |   |   |   |   |-- css-image-set.js
    |   |   |   |   |-- css-indeterminate-pseudo.js
    |   |   |   |   |-- css-initial-letter.js
    |   |   |   |   |-- css-initial-value.js
    |   |   |   |   |-- css-in-out-of-range.js
    |   |   |   |   |-- css-lch-lab.js
    |   |   |   |   |-- css-letter-spacing.js
    |   |   |   |   |-- css-line-clamp.js
    |   |   |   |   |-- css-logical-props.js
    |   |   |   |   |-- css-marker-pseudo.js
    |   |   |   |   |-- css-masks.js
    |   |   |   |   |-- css-matches-pseudo.js
    |   |   |   |   |-- css-math-functions.js
    |   |   |   |   |-- css-media-interaction.js
    |   |   |   |   |-- css-mediaqueries.js
    |   |   |   |   |-- css-media-range-syntax.js
    |   |   |   |   |-- css-media-resolution.js
    |   |   |   |   |-- css-media-scripting.js
    |   |   |   |   |-- css-mixblendmode.js
    |   |   |   |   |-- css-module-scripts.js
    |   |   |   |   |-- css-motion-paths.js
    |   |   |   |   |-- css-namespaces.js
    |   |   |   |   |-- css-nesting.js
    |   |   |   |   |-- css-not-sel-list.js
    |   |   |   |   |-- css-nth-child-of.js
    |   |   |   |   |-- css-opacity.js
    |   |   |   |   |-- css-optional-pseudo.js
    |   |   |   |   |-- css-overflow-anchor.js
    |   |   |   |   |-- css-overflow.js
    |   |   |   |   |-- css-overflow-overlay.js
    |   |   |   |   |-- css-overscroll-behavior.js
    |   |   |   |   |-- css-page-break.js
    |   |   |   |   |-- css-paged-media.js
    |   |   |   |   |-- css-paint-api.js
    |   |   |   |   |-- css-placeholder.js
    |   |   |   |   |-- css-placeholder-shown.js
    |   |   |   |   |-- css-print-color-adjust.js
    |   |   |   |   |-- css-read-only-write.js
    |   |   |   |   |-- css-rebeccapurple.js
    |   |   |   |   |-- css-reflections.js
    |   |   |   |   |-- css-regions.js
    |   |   |   |   |-- css-relative-colors.js
    |   |   |   |   |-- css-repeating-gradients.js
    |   |   |   |   |-- css-resize.js
    |   |   |   |   |-- css-revert-value.js
    |   |   |   |   |-- css-rrggbbaa.js
    |   |   |   |   |-- css-scrollbar.js
    |   |   |   |   |-- css-scroll-behavior.js
    |   |   |   |   |-- css-sel2.js
    |   |   |   |   |-- css-sel3.js
    |   |   |   |   |-- css-selection.js
    |   |   |   |   |-- css-shapes.js
    |   |   |   |   |-- css-snappoints.js
    |   |   |   |   |-- css-sticky.js
    |   |   |   |   |-- css-subgrid.js
    |   |   |   |   |-- css-supports-api.js
    |   |   |   |   |-- css-table.js
    |   |   |   |   |-- css-text-align-last.js
    |   |   |   |   |-- css-text-box-trim.js
    |   |   |   |   |-- css-text-indent.js
    |   |   |   |   |-- css-text-justify.js
    |   |   |   |   |-- css-text-orientation.js
    |   |   |   |   |-- css-textshadow.js
    |   |   |   |   |-- css-text-spacing.js
    |   |   |   |   |-- css-text-wrap-balance.js
    |   |   |   |   |-- css-touch-action.js
    |   |   |   |   |-- css-transitions.js
    |   |   |   |   |-- css-unicode-bidi.js
    |   |   |   |   |-- css-unset-value.js
    |   |   |   |   |-- css-variables.js
    |   |   |   |   |-- css-when-else.js
    |   |   |   |   |-- css-widows-orphans.js
    |   |   |   |   |-- css-width-stretch.js
    |   |   |   |   |-- css-writing-mode.js
    |   |   |   |   |-- css-zoom.js
    |   |   |   |   |-- currentcolor.js
    |   |   |   |   |-- custom-elements.js
    |   |   |   |   |-- custom-elementsv1.js
    |   |   |   |   |-- customevent.js
    |   |   |   |   |-- datalist.js
    |   |   |   |   |-- dataset.js
    |   |   |   |   |-- datauri.js
    |   |   |   |   |-- date-tolocaledatestring.js
    |   |   |   |   |-- declarative-shadow-dom.js
    |   |   |   |   |-- decorators.js
    |   |   |   |   |-- details.js
    |   |   |   |   |-- deviceorientation.js
    |   |   |   |   |-- devicepixelratio.js
    |   |   |   |   |-- dialog.js
    |   |   |   |   |-- dispatchevent.js
    |   |   |   |   |-- dnssec.js
    |   |   |   |   |-- document-currentscript.js
    |   |   |   |   |-- document-evaluate-xpath.js
    |   |   |   |   |-- document-execcommand.js
    |   |   |   |   |-- documenthead.js
    |   |   |   |   |-- document-policy.js
    |   |   |   |   |-- document-scrollingelement.js
    |   |   |   |   |-- domcontentloaded.js
    |   |   |   |   |-- dom-manip-convenience.js
    |   |   |   |   |-- dommatrix.js
    |   |   |   |   |-- dom-range.js
    |   |   |   |   |-- do-not-track.js
    |   |   |   |   |-- download.js
    |   |   |   |   |-- dragndrop.js
    |   |   |   |   |-- element-closest.js
    |   |   |   |   |-- element-from-point.js
    |   |   |   |   |-- element-scroll-methods.js
    |   |   |   |   |-- eme.js
    |   |   |   |   |-- eot.js
    |   |   |   |   |-- es5.js
    |   |   |   |   |-- es6-class.js
    |   |   |   |   |-- es6-generators.js
    |   |   |   |   |-- es6.js
    |   |   |   |   |-- es6-module-dynamic-import.js
    |   |   |   |   |-- es6-module.js
    |   |   |   |   |-- es6-number.js
    |   |   |   |   |-- es6-string-includes.js
    |   |   |   |   |-- eventsource.js
    |   |   |   |   |-- extended-system-fonts.js
    |   |   |   |   |-- feature-policy.js
    |   |   |   |   |-- fetch.js
    |   |   |   |   |-- fieldset-disabled.js
    |   |   |   |   |-- fileapi.js
    |   |   |   |   |-- filereader.js
    |   |   |   |   |-- filereadersync.js
    |   |   |   |   |-- filesystem.js
    |   |   |   |   |-- flac.js
    |   |   |   |   |-- flexbox-gap.js
    |   |   |   |   |-- flexbox.js
    |   |   |   |   |-- flow-root.js
    |   |   |   |   |-- focusin-focusout-events.js
    |   |   |   |   |-- fontface.js
    |   |   |   |   |-- font-family-system-ui.js
    |   |   |   |   |-- font-feature.js
    |   |   |   |   |-- font-kerning.js
    |   |   |   |   |-- font-loading.js
    |   |   |   |   |-- font-size-adjust.js
    |   |   |   |   |-- font-smooth.js
    |   |   |   |   |-- font-unicode-range.js
    |   |   |   |   |-- font-variant-alternates.js
    |   |   |   |   |-- font-variant-numeric.js
    |   |   |   |   |-- form-attribute.js
    |   |   |   |   |-- forms.js
    |   |   |   |   |-- form-submit-attributes.js
    |   |   |   |   |-- form-validation.js
    |   |   |   |   |-- fullscreen.js
    |   |   |   |   |-- gamepad.js
    |   |   |   |   |-- geolocation.js
    |   |   |   |   |-- getboundingclientrect.js
    |   |   |   |   |-- getcomputedstyle.js
    |   |   |   |   |-- getelementsbyclassname.js
    |   |   |   |   |-- getrandomvalues.js
    |   |   |   |   |-- gyroscope.js
    |   |   |   |   |-- hardwareconcurrency.js
    |   |   |   |   |-- hashchange.js
    |   |   |   |   |-- heif.js
    |   |   |   |   |-- hevc.js
    |   |   |   |   |-- hidden.js
    |   |   |   |   |-- high-resolution-time.js
    |   |   |   |   |-- history.js
    |   |   |   |   |-- html5semantic.js
    |   |   |   |   |-- html-media-capture.js
    |   |   |   |   |-- http2.js
    |   |   |   |   |-- http3.js
    |   |   |   |   |-- http-live-streaming.js
    |   |   |   |   |-- iframe-sandbox.js
    |   |   |   |   |-- iframe-seamless.js
    |   |   |   |   |-- iframe-srcdoc.js
    |   |   |   |   |-- imagecapture.js
    |   |   |   |   |-- ime.js
    |   |   |   |   |-- img-naturalwidth-naturalheight.js
    |   |   |   |   |-- import-maps.js
    |   |   |   |   |-- imports.js
    |   |   |   |   |-- indeterminate-checkbox.js
    |   |   |   |   |-- indexeddb2.js
    |   |   |   |   |-- indexeddb.js
    |   |   |   |   |-- inline-block.js
    |   |   |   |   |-- innertext.js
    |   |   |   |   |-- input-autocomplete-onoff.js
    |   |   |   |   |-- input-color.js
    |   |   |   |   |-- input-datetime.js
    |   |   |   |   |-- input-email-tel-url.js
    |   |   |   |   |-- input-event.js
    |   |   |   |   |-- input-file-accept.js
    |   |   |   |   |-- input-file-directory.js
    |   |   |   |   |-- input-file-multiple.js
    |   |   |   |   |-- input-inputmode.js
    |   |   |   |   |-- input-minlength.js
    |   |   |   |   |-- input-number.js
    |   |   |   |   |-- input-pattern.js
    |   |   |   |   |-- input-placeholder.js
    |   |   |   |   |-- input-range.js
    |   |   |   |   |-- input-search.js
    |   |   |   |   |-- input-selection.js
    |   |   |   |   |-- insertadjacenthtml.js
    |   |   |   |   |-- insert-adjacent.js
    |   |   |   |   |-- internationalization.js
    |   |   |   |   |-- intersectionobserver.js
    |   |   |   |   |-- intersectionobserver-v2.js
    |   |   |   |   |-- intl-pluralrules.js
    |   |   |   |   |-- intrinsic-width.js
    |   |   |   |   |-- jpeg2000.js
    |   |   |   |   |-- jpegxl.js
    |   |   |   |   |-- jpegxr.js
    |   |   |   |   |-- json.js
    |   |   |   |   |-- js-regexp-lookbehind.js
    |   |   |   |   |-- justify-content-space-evenly.js
    |   |   |   |   |-- kerning-pairs-ligatures.js
    |   |   |   |   |-- keyboardevent-charcode.js
    |   |   |   |   |-- keyboardevent-code.js
    |   |   |   |   |-- keyboardevent-getmodifierstate.js
    |   |   |   |   |-- keyboardevent-key.js
    |   |   |   |   |-- keyboardevent-location.js
    |   |   |   |   |-- keyboardevent-which.js
    |   |   |   |   |-- lazyload.js
    |   |   |   |   |-- let.js
    |   |   |   |   |-- link-icon-png.js
    |   |   |   |   |-- link-icon-svg.js
    |   |   |   |   |-- link-rel-dns-prefetch.js
    |   |   |   |   |-- link-rel-modulepreload.js
    |   |   |   |   |-- link-rel-preconnect.js
    |   |   |   |   |-- link-rel-prefetch.js
    |   |   |   |   |-- link-rel-preload.js
    |   |   |   |   |-- link-rel-prerender.js
    |   |   |   |   |-- loading-lazy-attr.js
    |   |   |   |   |-- localecompare.js
    |   |   |   |   |-- magnetometer.js
    |   |   |   |   |-- matchesselector.js
    |   |   |   |   |-- matchmedia.js
    |   |   |   |   |-- mathml.js
    |   |   |   |   |-- maxlength.js
    |   |   |   |   |-- mdn-css-backdrop-pseudo-element.js
    |   |   |   |   |-- mdn-css-unicode-bidi-isolate.js
    |   |   |   |   |-- mdn-css-unicode-bidi-isolate-override.js
    |   |   |   |   |-- mdn-css-unicode-bidi-plaintext.js
    |   |   |   |   |-- mdn-text-decoration-color.js
    |   |   |   |   |-- mdn-text-decoration-line.js
    |   |   |   |   |-- mdn-text-decoration-shorthand.js
    |   |   |   |   |-- mdn-text-decoration-style.js
    |   |   |   |   |-- mediacapture-fromelement.js
    |   |   |   |   |-- media-fragments.js
    |   |   |   |   |-- mediarecorder.js
    |   |   |   |   |-- mediasource.js
    |   |   |   |   |-- menu.js
    |   |   |   |   |-- meta-theme-color.js
    |   |   |   |   |-- meter.js
    |   |   |   |   |-- midi.js
    |   |   |   |   |-- minmaxwh.js
    |   |   |   |   |-- mp3.js
    |   |   |   |   |-- mpeg4.js
    |   |   |   |   |-- mpeg-dash.js
    |   |   |   |   |-- multibackgrounds.js
    |   |   |   |   |-- multicolumn.js
    |   |   |   |   |-- mutation-events.js
    |   |   |   |   |-- mutationobserver.js
    |   |   |   |   |-- namevalue-storage.js
    |   |   |   |   |-- native-filesystem-api.js
    |   |   |   |   |-- nav-timing.js
    |   |   |   |   |-- netinfo.js
    |   |   |   |   |-- notifications.js
    |   |   |   |   |-- object-entries.js
    |   |   |   |   |-- object-fit.js
    |   |   |   |   |-- object-observe.js
    |   |   |   |   |-- objectrtc.js
    |   |   |   |   |-- object-values.js
    |   |   |   |   |-- offline-apps.js
    |   |   |   |   |-- offscreencanvas.js
    |   |   |   |   |-- ogg-vorbis.js
    |   |   |   |   |-- ogv.js
    |   |   |   |   |-- ol-reversed.js
    |   |   |   |   |-- once-event-listener.js
    |   |   |   |   |-- online-status.js
    |   |   |   |   |-- opus.js
    |   |   |   |   |-- orientation-sensor.js
    |   |   |   |   |-- outline.js
    |   |   |   |   |-- pad-start-end.js
    |   |   |   |   |-- page-transition-events.js
    |   |   |   |   |-- pagevisibility.js
    |   |   |   |   |-- passive-event-listener.js
    |   |   |   |   |-- passkeys.js
    |   |   |   |   |-- passwordrules.js
    |   |   |   |   |-- path2d.js
    |   |   |   |   |-- payment-request.js
    |   |   |   |   |-- pdf-viewer.js
    |   |   |   |   |-- permissions-api.js
    |   |   |   |   |-- permissions-policy.js
    |   |   |   |   |-- picture-in-picture.js
    |   |   |   |   |-- picture.js
    |   |   |   |   |-- ping.js
    |   |   |   |   |-- png-alpha.js
    |   |   |   |   |-- pointer-events.js
    |   |   |   |   |-- pointer.js
    |   |   |   |   |-- pointerlock.js
    |   |   |   |   |-- portals.js
    |   |   |   |   |-- prefers-color-scheme.js
    |   |   |   |   |-- prefers-reduced-motion.js
    |   |   |   |   |-- progress.js
    |   |   |   |   |-- promise-finally.js
    |   |   |   |   |-- promises.js
    |   |   |   |   |-- proximity.js
    |   |   |   |   |-- proxy.js
    |   |   |   |   |-- publickeypinning.js
    |   |   |   |   |-- push-api.js
    |   |   |   |   |-- queryselector.js
    |   |   |   |   |-- readonly-attr.js
    |   |   |   |   |-- referrer-policy.js
    |   |   |   |   |-- registerprotocolhandler.js
    |   |   |   |   |-- rellist.js
    |   |   |   |   |-- rel-noopener.js
    |   |   |   |   |-- rel-noreferrer.js
    |   |   |   |   |-- rem.js
    |   |   |   |   |-- requestanimationframe.js
    |   |   |   |   |-- requestidlecallback.js
    |   |   |   |   |-- resizeobserver.js
    |   |   |   |   |-- resource-timing.js
    |   |   |   |   |-- rest-parameters.js
    |   |   |   |   |-- rtcpeerconnection.js
    |   |   |   |   |-- ruby.js
    |   |   |   |   |-- run-in.js
    |   |   |   |   |-- same-site-cookie-attribute.js
    |   |   |   |   |-- screen-orientation.js
    |   |   |   |   |-- script-async.js
    |   |   |   |   |-- script-defer.js
    |   |   |   |   |-- scrollintoviewifneeded.js
    |   |   |   |   |-- scrollintoview.js
    |   |   |   |   |-- sdch.js
    |   |   |   |   |-- selection-api.js
    |   |   |   |   |-- selectlist.js
    |   |   |   |   |-- server-timing.js
    |   |   |   |   |-- serviceworkers.js
    |   |   |   |   |-- setimmediate.js
    |   |   |   |   |-- shadowdom.js
    |   |   |   |   |-- shadowdomv1.js
    |   |   |   |   |-- sharedarraybuffer.js
    |   |   |   |   |-- sharedworkers.js
    |   |   |   |   |-- sni.js
    |   |   |   |   |-- spdy.js
    |   |   |   |   |-- speech-recognition.js
    |   |   |   |   |-- speech-synthesis.js
    |   |   |   |   |-- spellcheck-attribute.js
    |   |   |   |   |-- sql-storage.js
    |   |   |   |   |-- srcset.js
    |   |   |   |   |-- stream.js
    |   |   |   |   |-- streams.js
    |   |   |   |   |-- stricttransportsecurity.js
    |   |   |   |   |-- style-scoped.js
    |   |   |   |   |-- subresource-bundling.js
    |   |   |   |   |-- subresource-integrity.js
    |   |   |   |   |-- svg-css.js
    |   |   |   |   |-- svg-filters.js
    |   |   |   |   |-- svg-fonts.js
    |   |   |   |   |-- svg-fragment.js
    |   |   |   |   |-- svg-html5.js
    |   |   |   |   |-- svg-html.js
    |   |   |   |   |-- svg-img.js
    |   |   |   |   |-- svg.js
    |   |   |   |   |-- svg-smil.js
    |   |   |   |   |-- sxg.js
    |   |   |   |   |-- tabindex-attr.js
    |   |   |   |   |-- template.js
    |   |   |   |   |-- template-literals.js
    |   |   |   |   |-- temporal.js
    |   |   |   |   |-- testfeat.js
    |   |   |   |   |-- textcontent.js
    |   |   |   |   |-- text-decoration.js
    |   |   |   |   |-- text-emphasis.js
    |   |   |   |   |-- textencoder.js
    |   |   |   |   |-- text-overflow.js
    |   |   |   |   |-- text-size-adjust.js
    |   |   |   |   |-- text-stroke.js
    |   |   |   |   |-- tls1-1.js
    |   |   |   |   |-- tls1-2.js
    |   |   |   |   |-- tls1-3.js
    |   |   |   |   |-- touch.js
    |   |   |   |   |-- transforms2d.js
    |   |   |   |   |-- transforms3d.js
    |   |   |   |   |-- trusted-types.js
    |   |   |   |   |-- ttf.js
    |   |   |   |   |-- typedarrays.js
    |   |   |   |   |-- u2f.js
    |   |   |   |   |-- unhandledrejection.js
    |   |   |   |   |-- upgradeinsecurerequests.js
    |   |   |   |   |-- url.js
    |   |   |   |   |-- url-scroll-to-text-fragment.js
    |   |   |   |   |-- urlsearchparams.js
    |   |   |   |   |-- user-select-none.js
    |   |   |   |   |-- user-timing.js
    |   |   |   |   |-- use-strict.js
    |   |   |   |   |-- variable-fonts.js
    |   |   |   |   |-- vector-effect.js
    |   |   |   |   |-- vibration.js
    |   |   |   |   |-- video.js
    |   |   |   |   |-- videotracks.js
    |   |   |   |   |-- viewport-units.js
    |   |   |   |   |-- viewport-unit-variants.js
    |   |   |   |   |-- view-transitions.js
    |   |   |   |   |-- wai-aria.js
    |   |   |   |   |-- wake-lock.js
    |   |   |   |   |-- wasm-bigint.js
    |   |   |   |   |-- wasm-bulk-memory.js
    |   |   |   |   |-- wasm-extended-const.js
    |   |   |   |   |-- wasm-gc.js
    |   |   |   |   |-- wasm.js
    |   |   |   |   |-- wasm-multi-memory.js
    |   |   |   |   |-- wasm-multi-value.js
    |   |   |   |   |-- wasm-mutable-globals.js
    |   |   |   |   |-- wasm-nontrapping-fptoint.js
    |   |   |   |   |-- wasm-reference-types.js
    |   |   |   |   |-- wasm-relaxed-simd.js
    |   |   |   |   |-- wasm-signext.js
    |   |   |   |   |-- wasm-simd.js
    |   |   |   |   |-- wasm-tail-calls.js
    |   |   |   |   |-- wasm-threads.js
    |   |   |   |   |-- wav.js
    |   |   |   |   |-- wbr-element.js
    |   |   |   |   |-- web-animation.js
    |   |   |   |   |-- web-app-manifest.js
    |   |   |   |   |-- webauthn.js
    |   |   |   |   |-- web-bluetooth.js
    |   |   |   |   |-- webcodecs.js
    |   |   |   |   |-- webgl2.js
    |   |   |   |   |-- webgl.js
    |   |   |   |   |-- webgpu.js
    |   |   |   |   |-- webhid.js
    |   |   |   |   |-- webkit-user-drag.js
    |   |   |   |   |-- webm.js
    |   |   |   |   |-- webnfc.js
    |   |   |   |   |-- webp.js
    |   |   |   |   |-- web-serial.js
    |   |   |   |   |-- web-share.js
    |   |   |   |   |-- websockets.js
    |   |   |   |   |-- webtransport.js
    |   |   |   |   |-- webusb.js
    |   |   |   |   |-- webvr.js
    |   |   |   |   |-- webvtt.js
    |   |   |   |   |-- webworkers.js
    |   |   |   |   |-- webxr.js
    |   |   |   |   |-- will-change.js
    |   |   |   |   |-- woff2.js
    |   |   |   |   |-- woff.js
    |   |   |   |   |-- word-break.js
    |   |   |   |   |-- wordwrap.js
    |   |   |   |   |-- x-doc-messaging.js
    |   |   |   |   |-- x-frame-options.js
    |   |   |   |   |-- xhr2.js
    |   |   |   |   |-- xhtml.js
    |   |   |   |   |-- xhtmlsmil.js
    |   |   |   |   |-- xml-serializer.js
    |   |   |   |   `-- zstd.js
    |   |   |   |-- features.js
    |   |   |   `-- regions
    |   |   |       |-- AD.js
    |   |   |       |-- AE.js
    |   |   |       |-- AF.js
    |   |   |       |-- AG.js
    |   |   |       |-- AI.js
    |   |   |       |-- AL.js
    |   |   |       |-- alt-af.js
    |   |   |       |-- alt-an.js
    |   |   |       |-- alt-as.js
    |   |   |       |-- alt-eu.js
    |   |   |       |-- alt-na.js
    |   |   |       |-- alt-oc.js
    |   |   |       |-- alt-sa.js
    |   |   |       |-- alt-ww.js
    |   |   |       |-- AM.js
    |   |   |       |-- AO.js
    |   |   |       |-- AR.js
    |   |   |       |-- AS.js
    |   |   |       |-- AT.js
    |   |   |       |-- AU.js
    |   |   |       |-- AW.js
    |   |   |       |-- AX.js
    |   |   |       |-- AZ.js
    |   |   |       |-- BA.js
    |   |   |       |-- BB.js
    |   |   |       |-- BD.js
    |   |   |       |-- BE.js
    |   |   |       |-- BF.js
    |   |   |       |-- BG.js
    |   |   |       |-- BH.js
    |   |   |       |-- BI.js
    |   |   |       |-- BJ.js
    |   |   |       |-- BM.js
    |   |   |       |-- BN.js
    |   |   |       |-- BO.js
    |   |   |       |-- BR.js
    |   |   |       |-- BS.js
    |   |   |       |-- BT.js
    |   |   |       |-- BW.js
    |   |   |       |-- BY.js
    |   |   |       |-- BZ.js
    |   |   |       |-- CA.js
    |   |   |       |-- CD.js
    |   |   |       |-- CF.js
    |   |   |       |-- CG.js
    |   |   |       |-- CH.js
    |   |   |       |-- CI.js
    |   |   |       |-- CK.js
    |   |   |       |-- CL.js
    |   |   |       |-- CM.js
    |   |   |       |-- CN.js
    |   |   |       |-- CO.js
    |   |   |       |-- CR.js
    |   |   |       |-- CU.js
    |   |   |       |-- CV.js
    |   |   |       |-- CX.js
    |   |   |       |-- CY.js
    |   |   |       |-- CZ.js
    |   |   |       |-- DE.js
    |   |   |       |-- DJ.js
    |   |   |       |-- DK.js
    |   |   |       |-- DM.js
    |   |   |       |-- DO.js
    |   |   |       |-- DZ.js
    |   |   |       |-- EC.js
    |   |   |       |-- EE.js
    |   |   |       |-- EG.js
    |   |   |       |-- ER.js
    |   |   |       |-- ES.js
    |   |   |       |-- ET.js
    |   |   |       |-- FI.js
    |   |   |       |-- FJ.js
    |   |   |       |-- FK.js
    |   |   |       |-- FM.js
    |   |   |       |-- FO.js
    |   |   |       |-- FR.js
    |   |   |       |-- GA.js
    |   |   |       |-- GB.js
    |   |   |       |-- GD.js
    |   |   |       |-- GE.js
    |   |   |       |-- GF.js
    |   |   |       |-- GG.js
    |   |   |       |-- GH.js
    |   |   |       |-- GI.js
    |   |   |       |-- GL.js
    |   |   |       |-- GM.js
    |   |   |       |-- GN.js
    |   |   |       |-- GP.js
    |   |   |       |-- GQ.js
    |   |   |       |-- GR.js
    |   |   |       |-- GT.js
    |   |   |       |-- GU.js
    |   |   |       |-- GW.js
    |   |   |       |-- GY.js
    |   |   |       |-- HK.js
    |   |   |       |-- HN.js
    |   |   |       |-- HR.js
    |   |   |       |-- HT.js
    |   |   |       |-- HU.js
    |   |   |       |-- ID.js
    |   |   |       |-- IE.js
    |   |   |       |-- IL.js
    |   |   |       |-- IM.js
    |   |   |       |-- IN.js
    |   |   |       |-- IQ.js
    |   |   |       |-- IR.js
    |   |   |       |-- IS.js
    |   |   |       |-- IT.js
    |   |   |       |-- JE.js
    |   |   |       |-- JM.js
    |   |   |       |-- JO.js
    |   |   |       |-- JP.js
    |   |   |       |-- KE.js
    |   |   |       |-- KG.js
    |   |   |       |-- KH.js
    |   |   |       |-- KI.js
    |   |   |       |-- KM.js
    |   |   |       |-- KN.js
    |   |   |       |-- KP.js
    |   |   |       |-- KR.js
    |   |   |       |-- KW.js
    |   |   |       |-- KY.js
    |   |   |       |-- KZ.js
    |   |   |       |-- LA.js
    |   |   |       |-- LB.js
    |   |   |       |-- LC.js
    |   |   |       |-- LI.js
    |   |   |       |-- LK.js
    |   |   |       |-- LR.js
    |   |   |       |-- LS.js
    |   |   |       |-- LT.js
    |   |   |       |-- LU.js
    |   |   |       |-- LV.js
    |   |   |       |-- LY.js
    |   |   |       |-- MA.js
    |   |   |       |-- MC.js
    |   |   |       |-- MD.js
    |   |   |       |-- ME.js
    |   |   |       |-- MG.js
    |   |   |       |-- MH.js
    |   |   |       |-- MK.js
    |   |   |       |-- ML.js
    |   |   |       |-- MM.js
    |   |   |       |-- MN.js
    |   |   |       |-- MO.js
    |   |   |       |-- MP.js
    |   |   |       |-- MQ.js
    |   |   |       |-- MR.js
    |   |   |       |-- MS.js
    |   |   |       |-- MT.js
    |   |   |       |-- MU.js
    |   |   |       |-- MV.js
    |   |   |       |-- MW.js
    |   |   |       |-- MX.js
    |   |   |       |-- MY.js
    |   |   |       |-- MZ.js
    |   |   |       |-- NA.js
    |   |   |       |-- NC.js
    |   |   |       |-- NE.js
    |   |   |       |-- NF.js
    |   |   |       |-- NG.js
    |   |   |       |-- NI.js
    |   |   |       |-- NL.js
    |   |   |       |-- NO.js
    |   |   |       |-- NP.js
    |   |   |       |-- NR.js
    |   |   |       |-- NU.js
    |   |   |       |-- NZ.js
    |   |   |       |-- OM.js
    |   |   |       |-- PA.js
    |   |   |       |-- PE.js
    |   |   |       |-- PF.js
    |   |   |       |-- PG.js
    |   |   |       |-- PH.js
    |   |   |       |-- PK.js
    |   |   |       |-- PL.js
    |   |   |       |-- PM.js
    |   |   |       |-- PN.js
    |   |   |       |-- PR.js
    |   |   |       |-- PS.js
    |   |   |       |-- PT.js
    |   |   |       |-- PW.js
    |   |   |       |-- PY.js
    |   |   |       |-- QA.js
    |   |   |       |-- RE.js
    |   |   |       |-- RO.js
    |   |   |       |-- RS.js
    |   |   |       |-- RU.js
    |   |   |       |-- RW.js
    |   |   |       |-- SA.js
    |   |   |       |-- SB.js
    |   |   |       |-- SC.js
    |   |   |       |-- SD.js
    |   |   |       |-- SE.js
    |   |   |       |-- SG.js
    |   |   |       |-- SH.js
    |   |   |       |-- SI.js
    |   |   |       |-- SK.js
    |   |   |       |-- SL.js
    |   |   |       |-- SM.js
    |   |   |       |-- SN.js
    |   |   |       |-- SO.js
    |   |   |       |-- SR.js
    |   |   |       |-- ST.js
    |   |   |       |-- SV.js
    |   |   |       |-- SY.js
    |   |   |       |-- SZ.js
    |   |   |       |-- TC.js
    |   |   |       |-- TD.js
    |   |   |       |-- TG.js
    |   |   |       |-- TH.js
    |   |   |       |-- TJ.js
    |   |   |       |-- TL.js
    |   |   |       |-- TM.js
    |   |   |       |-- TN.js
    |   |   |       |-- TO.js
    |   |   |       |-- TR.js
    |   |   |       |-- TT.js
    |   |   |       |-- TV.js
    |   |   |       |-- TW.js
    |   |   |       |-- TZ.js
    |   |   |       |-- UA.js
    |   |   |       |-- UG.js
    |   |   |       |-- US.js
    |   |   |       |-- UY.js
    |   |   |       |-- UZ.js
    |   |   |       |-- VA.js
    |   |   |       |-- VC.js
    |   |   |       |-- VE.js
    |   |   |       |-- VG.js
    |   |   |       |-- VI.js
    |   |   |       |-- VN.js
    |   |   |       |-- VU.js
    |   |   |       |-- WF.js
    |   |   |       |-- WS.js
    |   |   |       |-- YE.js
    |   |   |       |-- YT.js
    |   |   |       |-- ZA.js
    |   |   |       |-- ZM.js
    |   |   |       `-- ZW.js
    |   |   |-- dist
    |   |   |   |-- lib
    |   |   |   |   |-- statuses.js
    |   |   |   |   `-- supported.js
    |   |   |   `-- unpacker
    |   |   |       |-- agents.js
    |   |   |       |-- browsers.js
    |   |   |       |-- browserVersions.js
    |   |   |       |-- feature.js
    |   |   |       |-- features.js
    |   |   |       |-- index.js
    |   |   |       `-- region.js
    |   |   |-- LICENSE
    |   |   `-- package.json
    |   |-- electron-to-chromium
    |   |   |-- chromium-versions.js
    |   |   |-- chromium-versions.json
    |   |   |-- full-chromium-versions.js
    |   |   |-- full-chromium-versions.json
    |   |   |-- full-versions.js
    |   |   |-- full-versions.json
    |   |   |-- index.js
    |   |   |-- LICENSE
    |   |   |-- package.json
    |   |   |-- versions.js
    |   |   `-- versions.json
    |   |-- escalade
    |   |   |-- dist
    |   |   |   |-- index.js
    |   |   |   `-- index.mjs
    |   |   |-- index.d.mts
    |   |   |-- index.d.ts
    |   |   |-- license
    |   |   |-- package.json
    |   |   |-- readme.md
    |   |   `-- sync
    |   |       |-- index.d.mts
    |   |       |-- index.d.ts
    |   |       |-- index.js
    |   |       `-- index.mjs
    |   |-- fraction.js
    |   |   |-- bigfraction.js
    |   |   |-- fraction.cjs
    |   |   |-- fraction.d.ts
    |   |   |-- fraction.js
    |   |   |-- fraction.min.js
    |   |   |-- LICENSE
    |   |   `-- package.json
    |   |-- nanoid
    |   |   |-- async
    |   |   |   |-- index.browser.cjs
    |   |   |   |-- index.browser.js
    |   |   |   |-- index.cjs
    |   |   |   |-- index.d.ts
    |   |   |   |-- index.js
    |   |   |   |-- index.native.js
    |   |   |   `-- package.json
    |   |   |-- index.browser.cjs
    |   |   |-- index.browser.js
    |   |   |-- index.cjs
    |   |   |-- index.d.cts
    |   |   |-- index.d.ts
    |   |   |-- index.js
    |   |   |-- LICENSE
    |   |   |-- nanoid.js
    |   |   |-- non-secure
    |   |   |   |-- index.cjs
    |   |   |   |-- index.d.ts
    |   |   |   |-- index.js
    |   |   |   `-- package.json
    |   |   |-- package.json
    |   |   `-- url-alphabet
    |   |       |-- index.cjs
    |   |       |-- index.js
    |   |       `-- package.json
    |   |-- node-releases
    |   |   |-- data
    |   |   |   |-- processed
    |   |   |   |   `-- envs.json
    |   |   |   `-- release-schedule
    |   |   |       `-- release-schedule.json
    |   |   |-- LICENSE
    |   |   `-- package.json
    |   |-- normalize-range
    |   |   |-- index.js
    |   |   |-- license
    |   |   |-- package.json
    |   |   `-- readme.md
    |   |-- .package-lock.json
    |   |-- picocolors
    |   |   |-- LICENSE
    |   |   |-- package.json
    |   |   |-- picocolors.browser.js
    |   |   |-- picocolors.d.ts
    |   |   |-- picocolors.js
    |   |   `-- types.d.ts
    |   |-- postcss
    |   |   |-- lib
    |   |   |   |-- at-rule.d.ts
    |   |   |   |-- at-rule.js
    |   |   |   |-- comment.d.ts
    |   |   |   |-- comment.js
    |   |   |   |-- container.d.ts
    |   |   |   |-- container.js
    |   |   |   |-- css-syntax-error.d.ts
    |   |   |   |-- css-syntax-error.js
    |   |   |   |-- declaration.d.ts
    |   |   |   |-- declaration.js
    |   |   |   |-- document.d.ts
    |   |   |   |-- document.js
    |   |   |   |-- fromJSON.d.ts
    |   |   |   |-- fromJSON.js
    |   |   |   |-- input.d.ts
    |   |   |   |-- input.js
    |   |   |   |-- lazy-result.d.ts
    |   |   |   |-- lazy-result.js
    |   |   |   |-- list.d.ts
    |   |   |   |-- list.js
    |   |   |   |-- map-generator.js
    |   |   |   |-- node.d.ts
    |   |   |   |-- node.js
    |   |   |   |-- no-work-result.d.ts
    |   |   |   |-- no-work-result.js
    |   |   |   |-- parse.d.ts
    |   |   |   |-- parse.js
    |   |   |   |-- parser.js
    |   |   |   |-- postcss.d.mts
    |   |   |   |-- postcss.d.ts
    |   |   |   |-- postcss.js
    |   |   |   |-- postcss.mjs
    |   |   |   |-- previous-map.d.ts
    |   |   |   |-- previous-map.js
    |   |   |   |-- processor.d.ts
    |   |   |   |-- processor.js
    |   |   |   |-- result.d.ts
    |   |   |   |-- result.js
    |   |   |   |-- root.d.ts
    |   |   |   |-- root.js
    |   |   |   |-- rule.d.ts
    |   |   |   |-- rule.js
    |   |   |   |-- stringifier.d.ts
    |   |   |   |-- stringifier.js
    |   |   |   |-- stringify.d.ts
    |   |   |   |-- stringify.js
    |   |   |   |-- symbols.js
    |   |   |   |-- terminal-highlight.js
    |   |   |   |-- tokenize.js
    |   |   |   |-- warning.d.ts
    |   |   |   |-- warning.js
    |   |   |   `-- warn-once.js
    |   |   |-- LICENSE
    |   |   `-- package.json
    |   |-- postcss-value-parser
    |   |   |-- lib
    |   |   |   |-- index.d.ts
    |   |   |   |-- index.js
    |   |   |   |-- parse.js
    |   |   |   |-- stringify.js
    |   |   |   |-- unit.js
    |   |   |   `-- walk.js
    |   |   |-- LICENSE
    |   |   `-- package.json
    |   |-- source-map-js
    |   |   |-- lib
    |   |   |   |-- array-set.js
    |   |   |   |-- base64.js
    |   |   |   |-- base64-vlq.js
    |   |   |   |-- binary-search.js
    |   |   |   |-- mapping-list.js
    |   |   |   |-- quick-sort.js
    |   |   |   |-- source-map-consumer.d.ts
    |   |   |   |-- source-map-consumer.js
    |   |   |   |-- source-map-generator.d.ts
    |   |   |   |-- source-map-generator.js
    |   |   |   |-- source-node.d.ts
    |   |   |   |-- source-node.js
    |   |   |   `-- util.js
    |   |   |-- LICENSE
    |   |   |-- package.json
    |   |   |-- source-map.d.ts
    |   |   `-- source-map.js
    |   |-- tailwindcss
    |   |   |-- dist
    |   |   |   |-- chunk-GFBUASX3.mjs
    |   |   |   |-- chunk-HTB5LLOP.mjs
    |   |   |   |-- chunk-MEY3PWYT.mjs
    |   |   |   |-- colors-b_6i0Oi7.d.ts
    |   |   |   |-- colors.d.mts
    |   |   |   |-- colors.d.ts
    |   |   |   |-- colors.js
    |   |   |   |-- colors.mjs
    |   |   |   |-- default-theme.d.mts
    |   |   |   |-- default-theme.d.ts
    |   |   |   |-- default-theme.js
    |   |   |   |-- default-theme.mjs
    |   |   |   |-- flatten-color-palette.d.mts
    |   |   |   |-- flatten-color-palette.d.ts
    |   |   |   |-- flatten-color-palette.js
    |   |   |   |-- flatten-color-palette.mjs
    |   |   |   |-- lib.d.mts
    |   |   |   |-- lib.d.ts
    |   |   |   |-- lib.js
    |   |   |   |-- lib.mjs
    |   |   |   |-- plugin.d.mts
    |   |   |   |-- plugin.d.ts
    |   |   |   |-- plugin.js
    |   |   |   |-- plugin.mjs
    |   |   |   |-- resolve-config-BIFUA2FY.d.ts
    |   |   |   |-- resolve-config-QUZ9b-Gn.d.mts
    |   |   |   `-- types-WlZgYgM8.d.mts
    |   |   |-- index.css
    |   |   |-- LICENSE
    |   |   |-- package.json
    |   |   |-- preflight.css
    |   |   |-- theme.css
    |   |   `-- utilities.css
    |   `-- update-browserslist-db
    |       |-- check-npm-version.js
    |       |-- cli.js
    |       |-- index.d.ts
    |       |-- index.js
    |       |-- LICENSE
    |       |-- package.json
    |       `-- utils.js
    |-- package.json
    `-- package-lock.json

84 directories, 1259 files
```
<!-- END STRUCTURE -->
---

## ⚙️ Configuração do Ambiente
---
### 1️⃣ Pré-requisitos
Antes de iniciar, garanta que você tenha instalado:
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker](https://www.docker.com/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)
- [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms)

### 2️⃣ Clonar o Repositório
```
git clone https://github.com/Big2109/Poc.git
cd Poc
```

-- TODO (3️⃣ Subir o Banco de Dados com Docker)
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourPassword123!" \
   -p 1433:1433 --name sqlserver \
   -d mcr.microsoft.com/mssql/server:2022-latest

### 4️⃣ Configurar o appsettings.json
Ajuste a connection string conforme necessário:

```
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=PortfolioDB;User Id=sa;Password=YourPassword123!;TrustServerCertificate=True;"
}
```
### 5️⃣ Aplicar as Migrations
```
dotnet ef database update
```
### 6️⃣ Executar o Projeto
```
dotnet run
```
A aplicação estará disponível em:
👉 https://localhost:5001
---
🧩 Funcionalidades
Página inicial com apresentação pessoal

Listagem dinâmica de projetos

Área administrativa para CRUD de projetos

Formulário de contato com persistência no banco

Design responsivo e moderno
---
🧠 Conceitos Aplicados
Padrão MVC (Model-View-Controller)

Injeção de dependências

Mapeamento objeto-relacional com Entity Framework Core

Migrations e Seed Data

Consumo de banco SQL via Docker

Boas práticas de organização e separação de camadas
---
🧰 Comandos Úteis
Ação	Comando
Criar migration	dotnet ef migrations add NomeDaMigration
Atualizar banco	dotnet ef database update
Executar projeto	dotnet run
Restaurar pacotes	dotnet restore
Publicar build	dotnet publish -c Release

👨‍💻 Autor
Eric Marques Bighi
[LinkedIn](https://www.linkedin.com/in/eric-bighi/) • [GitHub](https://github.com/Big2109)

