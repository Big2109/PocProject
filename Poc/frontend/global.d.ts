export { };

declare global {
    interface Window {
        showFeedbackModal: (tipo: string, msg: string, campos?: any) => void;
        showConfirmacaoModal: (msg: string) => void;
    }
}
