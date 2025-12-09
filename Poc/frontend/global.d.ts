export { };

declare global {
    interface Window {
        showFeedbackModal: (tipo: string, msg: string, campos?: any) => void;
        ShowModal: (id: string) => void;
        HideModal: (id: string) => void;
    }
}
