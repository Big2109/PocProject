export { };

declare global {
    interface Window {
        showFeedbackModal: (tipo: string, msg: string, campos?: any) => void;
        ShowConfirmacaoModal: (msg: string, id: string) => void;
    }
}
